
using AlzaCzEntryTask.Services.Swagger.Filters;

namespace AlzaCzEntryTask.Services.Swagger;
/// <summary>
/// Configures the Swagger generation options
/// </summary>
/// <remarks>This allows API versioning to define a Swagger document per API version after the
/// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _apiProvider;
    private readonly SwaggerConfig _swaggerConfig;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureSwaggerGenOptions"/> class.
    /// </summary>
    /// <param name="apiProvider">The API provider.</param>
    /// <param name="swaggerConfig">The swagger configuration.</param>
    /// <exception cref="System.ArgumentNullException">apiProvider</exception>
    public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider apiProvider, IOptions<SwaggerConfig> swaggerConfig)
    {
        _apiProvider = apiProvider ?? throw new ArgumentNullException(nameof(apiProvider));
        _swaggerConfig = swaggerConfig.Value;
    }

    /// <summary>
    /// Invoked to configure a TOptions instance.
    /// </summary>
    /// <param name="options">The options instance to configure.</param>
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _apiProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }

        options.IncludeXmlComments(GetXmlCommentsPath(), true);

        options.CustomSchemaIds(x => x.FullName);
    }

    private static string GetXmlCommentsPath()
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        return xmlPath;
    }

    /// <summary>
    /// Create API version
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = _swaggerConfig.Title,
            Version = description.ApiVersion.ToString(),
            Description = _swaggerConfig.Description,
            Contact = new OpenApiContact
            {
                Name = _swaggerConfig.ContactName,
                Email = _swaggerConfig.ContactEmail,
                Url = new Uri(_swaggerConfig.ContactUrl)
            },
            License = new OpenApiLicense
            {
                Name = _swaggerConfig.LicenseName,
                Url = new Uri(_swaggerConfig.LicenseUrl)
            }
        };
        if (description.IsDeprecated)
        {
            info.Description += " ** THIS API VERSION HAS BEEN DEPRECATED!";
        }
        return info;
    }
}
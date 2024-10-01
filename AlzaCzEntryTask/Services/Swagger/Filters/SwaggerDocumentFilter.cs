namespace AlzaCzEntryTask.Services.Swagger.Filters;

/// <summary>
/// Corresponding to Controller's API document description information
/// </summary>
public class SwaggerDocumentFilter : IDocumentFilter
{
    /// <summary>
    /// Applies the specified swagger document.
    /// </summary>
    /// <param name="swaggerDoc">The swagger document.</param>
    /// <param name="context">The context.</param>
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var tags = new List<OpenApiTag>
        {
            new()
            {
                Name = "Products",
                Description = "Endpoints for products",
                ExternalDocs = new OpenApiExternalDocs
                {
                    Description = "Source code",
                    Url = new Uri("https://github.com/sunamo/AlzaCzEntryTask")
                }
            }
        };

        // Sort in ascending order by AssemblyName
        swaggerDoc.Tags = tags.OrderBy(x => x.Name).ToList();
    }
}
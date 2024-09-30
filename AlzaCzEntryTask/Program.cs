
using Asp.Versioning;

namespace AlzaCzEntryTask;
class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;
        services.AddLogging(options =>
        {
            options.AddConsole();
        });
        services.AddScoped(provider =>
        {
            var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
            const string categoryName = "AlzaCzEntryTaskLogCategory";
            return loggerFactory.CreateLogger(categoryName);
        });

        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        IConfiguration config = configurationBuilder.Build();

        RegisterConfigurations(services, config);

        services.AddSingleton<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUiOptions>();
        services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("Swagger", new OpenApiInfo
            {
                Title = "",
                Version = ""
            });
        });

        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddDbContext<AlzaCzEntryTaskDbContext>();
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();
        var serviceScope = app.Services.CreateScope();
        var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger>();

        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature?.Error;
                if (exception != null)
                {
                    logger.LogError(exception.Message);
                }
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var errorResponse = new
                {
                    statusCode = 500,
                    message = "An unexpected server error occurred."
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
        app.Run();
    }

    private static void RegisterConfigurations(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SwaggerConfig>(configuration.GetSection(nameof(SwaggerConfig)));
    }
}
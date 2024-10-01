using AlzaCzEntryTask.Services;
using Asp.Versioning;

namespace AlzaCzEntryTask;

/// <summary>
/// Shared application startup functionality for both production and test environments
/// </summary>
public class Startup(IWebHostEnvironment env, IConfiguration config)
{
    /// <summary>
    /// Configure app after building service container
    /// </summary>
    /// <param name="app"></param>
    public void Configure(IApplicationBuilder app)
    {
        var logger = app.ApplicationServices.GetService<ILogger>();

        if (logger == null)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        }

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

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

        app.UseRouting();
        app.UseEndpoints(configure =>
        {
            configure.MapControllers();
        });
    }

    /// <summary>
    /// Configure services to inject through DI
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
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

        RegisterConfigurations(services);

        services.AddSingleton<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUiOptions>();
        services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
        services.AddSingleton<DbInitializer>();

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
            //options.ReportApiVersions = true;
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddDbContext<AlzaCzEntryTaskDbContext>();
    }

    private void RegisterConfigurations(IServiceCollection services)
    {
        services.Configure<SwaggerConfig>(config.GetSection(nameof(SwaggerConfig)));
    }
}

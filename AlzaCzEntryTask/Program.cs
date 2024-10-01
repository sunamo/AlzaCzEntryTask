using AlzaCzEntryTask.Services;

namespace AlzaCzEntryTask;
class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var dbInitializer = host.Services.GetRequiredService<DbInitializer>();
        dbInitializer.Initialize();
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseDefaultServiceProvider(options => { })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>().UseKestrel();
            })
            .ConfigureAppConfiguration((builderContext, config) =>
            {
                var env = builderContext.HostingEnvironment;
                config.SetBasePath(env.ContentRootPath);
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            });




}
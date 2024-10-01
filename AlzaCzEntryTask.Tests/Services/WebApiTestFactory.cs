
namespace AlzaCzHomework.Tests.Services;
public class WebApiTestFactory : WebApplicationFactory<Startup>
{
    private readonly InMemoryDatabaseRoot _databaseRoot = new();
    private readonly string _connectionString = Guid.NewGuid().ToString();
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .UseContentRoot(".")
            .UseTestServer()
            .UseEnvironment("Test")
            .ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AlzaCzEntryTaskDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                var serviceProvider = new ServiceCollection()
                  .AddEntityFrameworkInMemoryDatabase()
                  .BuildServiceProvider();
                services.AddDbContext<AlzaCzEntryTaskDbContext>(options =>
                {
                    options.UseInMemoryDatabase(_connectionString, _databaseRoot);
                    options.UseInternalServiceProvider(serviceProvider);
                });
                using (var serviceScope = services.BuildServiceProvider().CreateScope())
                {
                    var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger>();
                    try
                    {
                        var seeder = serviceScope.ServiceProvider.GetRequiredService<DbInitializer>();
                        seeder.Initialize();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                    }
                }
            });
        base.ConfigureWebHost(builder);
    }
}
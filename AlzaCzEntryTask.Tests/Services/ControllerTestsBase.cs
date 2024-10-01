
namespace AlzaCzHomework.Tests.Services;
public class ControllerTestsBase : IClassFixture<WebApiTestFactory>
{
    protected HttpClient Client;
    public ControllerTestsBase(WebApiTestFactory factory)
    {
        var options = new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true
        };
        Client = factory.CreateClient(options);
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}
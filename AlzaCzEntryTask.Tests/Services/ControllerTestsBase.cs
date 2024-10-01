
namespace AlzaCzHomework.Tests.Services;
public class ControllerTestsBase : IClassFixture<WebApiTestFactory>
{
    protected HttpClient Client;
    protected dynamic Token;
    public ControllerTestsBase(WebApiTestFactory factory)
    {
        var options = new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true
        };
        Client = factory.CreateClient(options);
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Token = new ExpandoObject();
        Token.sub = Guid.NewGuid();
        Token.role = new[] { "admin_role", "admin" };
    }
}
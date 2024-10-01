
using AlzaCzEntryTask.Data;
using AlzaCzEntryTask.Data.Request;

namespace AlzaCzHomework.Tests.IntegrationTests;
public class ProductsControllerTests : ControllerTestsBase
{
    private readonly string baseUrl;
    private readonly HttpClientHelper httpClientHelper;

    public ProductsControllerTests(WebApiTestFactory factory) : base(factory)
    {
        baseUrl = $"/api/v1/Products";
        httpClientHelper = new HttpClientHelper(Client);
    }

    private async Task<List<Product>> GetProducts()
    {
        var uri = baseUrl + "?pageNumberFrom1=1&pageSize=10";
        return await httpClientHelper.GetAsync<List<Product>>(uri);
    }

    private async Task<string> GetFirstProductDescription()
    {
        return (await GetProducts())[0].Description;
    }

    [Fact]
    public async Task GetProducts_ShouldReturnOkAndProducts()
    {
        // Act
        var companies = await GetProducts();

        // Assert
        Assert.True(companies.Any());
    }

    [Fact]
    public async Task UpdateDescription_NewDescriptionMustBeSaved()
    {
        // Arrange
        var firstProduct = (await GetProducts())[0];
        string updatedDescription = "Description";

        if (firstProduct.Description == updatedDescription)
        {
            updatedDescription += " with cool postfix";
        }

        var requestData = new UpdateDescriptionRequest { Id = firstProduct.Id, Description = updatedDescription };
        var data = JsonConvert.SerializeObject(requestData);

        // Act
        var result = await httpClientHelper.PatchAsync(baseUrl + "/Description", new StringContent(data, MediaTypeHeaderValue.Parse("application/json;charset=utf-8")));

        // Assert
        var firstProductAfterUpdated = (await GetProducts())[0];
        Assert.Equal(updatedDescription, firstProductAfterUpdated.Description);
    }
}
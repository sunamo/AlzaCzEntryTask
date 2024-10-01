
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        var result = await httpClientHelper.GetAsync<List<Product>>(uri);

        if (result.Item2.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException("GET /Products resulted with code " + result.Item2.StatusCode);
        }

        return result.Item1 ?? throw new InvalidOperationException("Products could not be obtained");
    }

    [Fact]
    public async Task GetProducts_ShouldReturnOkAndProducts()
    {
        // Act
        var companies = await GetProducts();

        // Assert
        Assert.True(companies.Count != 0);
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
        var result = await httpClientHelper.PatchAsync<HttpResponseMessage>(baseUrl + "/Description", new StringContent(data, MediaTypeHeaderValue.Parse("application/json;charset=utf-8")));
        var statusCode = result.Item2?.StatusCode ?? throw new InvalidOperationException("failed to call endpoint PATCH /Products/Description");

        // Assert
        Assert.Equal(updatedDescription, (await GetProducts())[0].Description);
        Assert.Equal(System.Net.HttpStatusCode.OK, statusCode);
    }
}
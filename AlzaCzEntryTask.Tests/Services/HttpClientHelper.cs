namespace AlzaCzHomework.Tests.Services;
public class HttpClientHelper(HttpClient httpHttpClient)
{
    public HttpClient Client { get; } = httpHttpClient;

    public async Task<T> GetAsync<T>(string path)
    {
        var response = await Client.GetAsync(path).ConfigureAwait(false);
        return await GetContentAsync<T>(response);
    }

    private static async Task<T> GetContentAsync<T>(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore
        };
        var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonConvert.DeserializeObject<T>(responseString, settings);
    }
}

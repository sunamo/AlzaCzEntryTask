namespace AlzaCzHomework.Tests.Services;
public class HttpClientHelper(HttpClient httpHttpClient)
{
    public HttpClient Client { get; } = httpHttpClient;

    public async Task<Tuple<T?, HttpResponseMessage>> GetAsync<T>(string path)
    {
        var response = await Client.GetAsync(path).ConfigureAwait(false);
        return await GetContentAsync<T>(response);
    }

    public async Task<Tuple<T?, HttpResponseMessage>> PatchAsync<T>(string path, HttpContent httpContent)
    {
        var response = await Client.PatchAsync(path, httpContent).ConfigureAwait(false);
        return await GetContentAsync<T>(response);
    }

    private static async Task<Tuple<T?, HttpResponseMessage>> GetContentAsync<T>(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore
        };
        var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return Tuple.Create(JsonConvert.DeserializeObject<T>(responseString, settings), response);
    }
}

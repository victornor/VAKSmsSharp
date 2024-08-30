using Newtonsoft.Json;
using Polly;
using Polly.Extensions.Http;

namespace VakSMSSharp.Services;

public abstract class BaseApiService
{
    protected string _apiKey;
    private readonly HttpClient _httpClient;
    
    public BaseApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> ExecuteRequestAsync<T>(string url, HttpMethod method, HttpContent content = null)
    {
        EnsureApiKey();
        
        var request = new HttpRequestMessage()
        {
            RequestUri = new Uri(url + (url.Contains('?') ? "&" : "?") + $"apiKey={_apiKey}"),
            Method = method,
            Content = content
        };

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }

    private void EnsureApiKey()
    {
        if (string.IsNullOrEmpty(_apiKey))
            throw new InvalidOperationException("API Key not set");
    }
}
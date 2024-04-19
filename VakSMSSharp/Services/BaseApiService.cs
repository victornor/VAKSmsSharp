using Newtonsoft.Json;
using Polly;
using Polly.Extensions.Http;

namespace VakSMSSharp.Services;

public abstract class BaseApiService
{
    private IAsyncPolicy<HttpResponseMessage> _requestPolicy = HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
            retryAttempt)));
    
    private string _apiKey { get; init; }
    private HttpClient _httpClient;
    
    public BaseApiService(string apiKey)
    {
        _apiKey = apiKey;

        _httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(15)
        };
    }

    public async Task<T> ExecuteRequestAsync<T>(string url, HttpMethod method, HttpContent content = null)
    {
        var response = await _requestPolicy.ExecuteAsync(async () =>
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url + (url.Contains('?') ? "&" : "?") + "apikey=" + _apiKey),
                Method = method,
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        });

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }
}
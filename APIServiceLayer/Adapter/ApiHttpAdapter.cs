using System.Net.Http;
using System.Net.Http.Json;

namespace APIServiceLayer.Adapter;

public class ApiHttpAdapter
{
    private readonly string _apiUrl;
    private readonly HttpClient _httpClient;

    protected ApiHttpAdapter(HttpClient httpClient, string apiUrl)
    {
        _httpClient = httpClient;
        _apiUrl = apiUrl;
    }

    public async Task<TResponse?> GetAsync<TResponse>(string endpoint)
    {
        var response = await _httpClient.GetFromJsonAsync<TResponse>($"{_apiUrl}/{endpoint}");
        return response;
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_apiUrl}/{endpoint}", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task DeleteAsync(string endpoint)
    {
        var response = await _httpClient.DeleteAsync($"{_apiUrl}/{endpoint}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_apiUrl}/{endpoint}", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }
}
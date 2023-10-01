using System.Net.Http.Headers;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace APIServiceLayer.Adapter;

public class ApiHttpAdapter : IApiHttpAdapter
{
    private readonly HttpClient _httpClient;

    public ApiHttpAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
        where TRequest : class
    {
        var response = await _httpClient.PostAsJsonAsync($"{endpoint}", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task DeleteAsync(string endpoint)
    {
        var response = await _httpClient.DeleteAsync($"{endpoint}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request)
        where TRequest : class
    {
        var response = await _httpClient.PutAsJsonAsync($"{endpoint}", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<TResponse?> GetAsync<TResponse>(string endpoint) where TResponse : class
    {
        var response = await _httpClient.GetFromJsonAsync<TResponse>($"{endpoint}");
        return response;
    }
}
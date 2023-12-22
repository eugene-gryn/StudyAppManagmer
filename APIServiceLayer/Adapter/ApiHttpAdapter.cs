using System.Net.Http.Json;
using APIServiceLayer.RequestFeedback;

namespace APIServiceLayer.Adapter;

public class ApiHttpAdapter : IApiHttpAdapter
{
    private readonly HttpClient _httpClient;

    public ApiHttpAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    private async Task EnsureSuccessServerResponse(HttpResponseMessage message)
    {
        try
        { 
            message.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            var content = await message.Content.ReadFromJsonAsync<ServerErrorResponse>();

            if (content != null) throw new RequestFeedbackException(content);

            throw;
        }
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
        where TRequest : class
    {
        var response = await _httpClient.PostAsJsonAsync($"{endpoint}", request);
        await EnsureSuccessServerResponse(response);
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task DeleteAsync(string endpoint)
    {
        var response = await _httpClient.DeleteAsync($"{endpoint}");
        await EnsureSuccessServerResponse(response);
    }

    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request)
        where TRequest : class
    {
        var response = await _httpClient.PutAsJsonAsync($"{endpoint}", request);
        await EnsureSuccessServerResponse(response);
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<TResponse?> GetAsync<TResponse>(string endpoint) where TResponse : class
    {
        var response = await _httpClient.GetFromJsonAsync<TResponse>($"{endpoint}");
        return response;
    }


}
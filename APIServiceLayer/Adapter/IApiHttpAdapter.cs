namespace APIServiceLayer.Adapter;

public interface IApiHttpAdapter
{
    Task<TResponse?> GetAsync<TResponse>(string endpoint) where TResponse : class;
    Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request) where TRequest : class;
    Task DeleteAsync(string endpoint);
    Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request) where TRequest : class;
}
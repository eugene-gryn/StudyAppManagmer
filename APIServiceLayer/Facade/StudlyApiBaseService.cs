using APIServiceLayer.Adapter;
using APIServiceLayer.Configuration;
using APIServiceLayer.Models;

namespace APIServiceLayer.Facade;

public abstract class StudlyApiBaseService
{
    protected readonly IApiHttpAdapter Adapter;
    protected readonly ApiEndpoints Links;

    protected StudlyApiBaseService(IApiHttpAdapter adapter, ApiEndpoints links)
    {
        Adapter = adapter;
        Links = links;
    }

    public abstract Task<string?> Login(UserLoginDto user);

    public abstract Task<bool> Register(UserRegisterDto data);

    public abstract Task<UserDTO?> GetUserData(string token);
}
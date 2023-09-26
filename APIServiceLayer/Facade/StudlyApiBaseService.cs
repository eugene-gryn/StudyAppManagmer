using APIServiceLayer.Adapter;
using APIServiceLayer.Configuration;
using APIServiceLayer.Models;

namespace APIServiceLayer.Facade;

public abstract class StudlyApiBaseService
{
    protected readonly IApiHttpAdapter Adapter;
    private readonly ConfigurationApiLinks _links;

    protected StudlyApiBaseService(IApiHttpAdapter adapter, ConfigurationApiLinks links)
    {
        Adapter = adapter;
        _links = links;
    }

    public abstract Task<string?> Login (UserLoginDto user);

    public abstract Task<bool> Register(UserRegisterDto data);

    public abstract Task<UserDTO?> GetUserData(string token);

}
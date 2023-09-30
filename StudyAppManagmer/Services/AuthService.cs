using System.Net;
using APIServiceLayer.Facade;
using APIServiceLayer.Models;
using MudBlazor;
using Newtonsoft.Json.Linq;
using YamlDotNet.Core.Tokens;

namespace StudyAppManagement.Services;

public class AuthService
{
    private readonly StudlyApiBaseService _apiService;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authService;

    public AuthService(StudlyApiBaseService ApiService, ILocalStorageService LocalStorage, AuthenticationStateProvider AuthService)
    {
        _apiService = ApiService;
        _localStorage = LocalStorage;
        _authService = AuthService;
    }

    public async Task<OperationResult> Login(UserLoginDto user)
    {
        TokenDto? token = new();

        try
        {
            token = await _apiService.Login(user);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
            if (e.StatusCode == HttpStatusCode.NotFound) return OperationResult.BadRequest;
            if (e.StatusCode == HttpStatusCode.NotImplemented) return OperationResult.ServerError;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        await _localStorage.SetItemAsStringAsync("user", token?.Value);

        await _authService.GetAuthenticationStateAsync();

        return OperationResult.Success;
    }
    public async Task<OperationResult> SingUp(UserRegisterDto user)
    {
        try
        {
            await _apiService.Register(user);
            return await Login(new UserLoginDto() { Email = user.Email, Password = user.Password });
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
            if (e.StatusCode == HttpStatusCode.NotFound) return OperationResult.BadRequest;
            if (e.StatusCode == HttpStatusCode.NotImplemented) return OperationResult.ServerError;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return OperationResult.Success;
    }

    public async Task<OperationResult> Logout()
    {
        await _localStorage.SetItemAsStringAsync("user", null);

        await _authService.GetAuthenticationStateAsync();

        return OperationResult.Success;
    }
}


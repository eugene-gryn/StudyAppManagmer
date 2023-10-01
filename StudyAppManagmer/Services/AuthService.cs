using System.Net;
using APIServiceLayer.Facade;
using APIServiceLayer.Models;

namespace StudyAppManagement.Services;

public class AuthService
{
    private readonly StudlyApiBaseService _apiService;
    private readonly AuthenticationStateProvider _authService;
    private readonly ILocalStorageService _localStorage;

    public AuthService(StudlyApiBaseService apiService, ILocalStorageService localStorage,
        AuthenticationStateProvider authService)
    {
        _apiService = apiService;
        _localStorage = localStorage;
        _authService = authService;
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
            return await Login(new UserLoginDto { Email = user.Email, Password = user.Password });
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
        await _localStorage.SetItemAsStringAsync("user", "");

        await _authService.GetAuthenticationStateAsync();

        return OperationResult.Success;
    }
}
using System.Net;
using APIServiceLayer.Facade;
using APIServiceLayer.Models;
using APIServiceLayer.RequestFeedback;

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

    public async Task<ServerErrorResponse> Login(UserLoginDto user)
    {
        try
        {
            TokenDto? token = new();

            token = await _apiService.Login(user);

            await _localStorage.SetItemAsStringAsync("user", token?.Value);

            await _authService.GetAuthenticationStateAsync();
        }
        catch (RequestFeedbackException e)
        {
            Console.WriteLine(e.BodyErrorModel.ExceptionMessage);

            return e.BodyErrorModel;
        }

        return new ServerErrorResponse();
    }

    public async Task<ServerErrorResponse> SingUp(UserRegisterDto user)
    {
        try
        {
            await _apiService.Register(user);
            return await Login(new UserLoginDto { Email = user.Email, Password = user.Password });
        }
        catch (RequestFeedbackException e)
        {
            Console.WriteLine(e.BodyErrorModel.ExceptionMessage);

            return e.BodyErrorModel;
        }
    }

    public async Task<ServerErrorResponse> Logout()
    {
        await _localStorage.SetItemAsStringAsync("user", "");

        await _authService.GetAuthenticationStateAsync();

        return new ServerErrorResponse();
    }
}
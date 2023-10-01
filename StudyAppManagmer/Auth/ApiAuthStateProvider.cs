using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace StudyAppManagement.Auth;

public class ApiAuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public ApiAuthStateProvider(ILocalStorageService localStorage, HttpClient http)
    {
        _localStorage = localStorage;
        _http = http;
    }


    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsStringAsync("user");

        ClaimsIdentity identity = new();
        _http.DefaultRequestHeaders.Authorization = null;

        try
        {
            identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        catch (InvalidOperationException a)
        {
            Console.WriteLine(a.Message);
        }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }


    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        try
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString() ?? string.Empty));
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error in processing authorization!", ex);
        }
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        try
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
            }

            return Convert.FromBase64String(base64);
        }
        catch (FormatException ex)
        {
            throw new InvalidOperationException("Auth token is invalid!", ex);
        }
    }
}
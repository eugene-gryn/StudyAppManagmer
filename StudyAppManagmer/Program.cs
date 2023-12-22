global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
using APIServiceLayer.Adapter;
using APIServiceLayer.Configuration;
using APIServiceLayer.Facade;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using StudyAppManagement;
using StudyAppManagement.Auth;
using StudyAppManagement.Services;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage();


// Project API Facade DI implementation

// Api links in configuration file
var apiLinks = new ApiEndpoints();
builder.Configuration.GetSection("ApiEndpoints").Bind(apiLinks);
builder.Services.AddSingleton(apiLinks);

builder.Services.AddScoped<IApiHttpAdapter, ApiHttpAdapter>();
builder.Services.AddScoped<StudlyApiBaseService, StudlyApiServiceFacade>();

// Other settings
builder.Services.AddScoped<AuthService>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 2000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

await builder.Build().RunAsync();
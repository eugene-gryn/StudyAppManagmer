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

builder.Services.AddScoped<IApiHttpAdapter, ApiHttpAdapter>(s => new ApiHttpAdapter(new HttpClient()));
builder.Services.AddScoped<StudlyApiBaseService, StudlyApiServiceFacade>();

// Other settings
builder.Services.AddScoped<AuthService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
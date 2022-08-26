using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;

using MudBlazor.Services;

using System.Globalization;
using System.Net.Http.Headers;

using Toolbelt.Blazor.Extensions.DependencyInjection;

using XtremeWasmApp;
using XtremeWasmApp.Models;
using XtremeWasmApp.Services;

#if DEBUG
//var HttpDataVar = new HttpData() { BaseAddress = new("http://localhost:2144/") };
HttpData HttpDataVar = new()
{
    BaseAddress = new("https://pbtsweb.azurewebsites.net/"),
    ReportingLink = new("https://xt.discreetnotation.com:8445/"),
    //ReportingLink = new("https://localhost:44313/"),
};

#elif RELEASE
HttpData HttpDataVar = new()
{
    BaseAddress = new("https://pbtsweb.azurewebsites.net/"),
    ReportingLink = new("https://xt.discreetnotation.com:8445/"),
};
#endif
var hubConnection = new HubConnectionBuilder()
            .WithUrl(HttpDataVar?.BaseAddress?.AbsoluteUri + "RefreshHub")
            .WithAutomaticReconnect(new TimeSpan[]
            {
                TimeSpan.FromSeconds(0),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(15),
            })
            .Build();
var cli = new HttpClient();
cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
var Curr = new CultureInfo("hi-IN");
Curr.NumberFormat.CurrencySymbol = "Rs.";
CultureInfo.DefaultThreadCurrentCulture = Curr;
CultureInfo.CurrentCulture = Curr;
CultureInfo.CurrentUICulture = Curr;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddLoadingBar(o => o.LoadingBarColor = "linear-gradient(90deg, rgba(227,0,0,1) 0%, rgba(37,33,98,1) 100%)");
builder.Services.AddScoped(_ => hubConnection);
builder.Services.AddScoped(_ => HttpDataVar ??= new());
builder.Services.AddScoped(sp => cli.EnableIntercept(sp));
builder.Services.AddScoped<IRefreshService, RefreshService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddMudServices();
builder.UseLoadingBar();
builder.Services.AddBlazorDownloadFile();
builder.Services.AddScoped<WebApiService>();

await builder.Build().RunAsync().ConfigureAwait(false);
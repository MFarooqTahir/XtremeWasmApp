using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using MudBlazor.Services;

using System.Net.Http.Headers;

using Toolbelt.Blazor.Extensions.DependencyInjection;

using XtremeWasmApp;
using XtremeWasmApp.Models;
using XtremeWasmApp.Services;

#if DEBUG
//var HttpDataVar = new HttpData() { BaseAddress = new("http://localhost:2144/") };
var HttpDataVar = new HttpData() { BaseAddress = new("http://localhost:2144/") };

#elif RELEASE
var HttpDataVar = new HttpData() { BaseAddress = new("https://pbtsweb.azurewebsites.net/") };
#endif
var cli = new HttpClient();
cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddLoadingBar(o => o.LoadingBarColor = "linear-gradient(90deg, rgba(227,0,0,1) 0%, rgba(37,33,98,1) 100%)");
builder.Services.AddScoped<HttpData>(_ => HttpDataVar);
builder.Services.AddScoped<HttpClient>(sp => cli.EnableIntercept(sp));
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IWebApiService, WebApiService>();
builder.Services.AddMudServices();
builder.UseLoadingBar();

await builder.Build().RunAsync().ConfigureAwait(false);
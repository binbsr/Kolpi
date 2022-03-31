using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Kolpi.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");

builder.Services.AddHttpClient("Kolpi.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Kolpi.ServerAPI"));

builder.Services.AddApiAuthorization();

builder.Services.AddMudServices();

await builder.Build().RunAsync();

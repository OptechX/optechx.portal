﻿using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OptechX.Portal.Client;
using OptechX.Portal.Client.Services;

namespace OptechX.Portal.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddBlazoredToast();  // toast notifications
        builder.Services.AddBlazoredLocalStorage();  // browser storage

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddScoped<IBananaService, BananaService>();
        builder.Services.AddScoped<IUnitService, UnitService>();
        builder.Services.AddScoped<ICountryListService, CountryListService>();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        builder.Services.AddOptions();
        builder.Services.AddAuthorizationCore();

        await builder.Build().RunAsync();
    }
}


using FriendlyGeekGameServerManager.Components;
using FriendlyGeekGameServerManager.Data;
using FriendlyGeekGameServerManager.Interfaces;
using MudBlazor.Services;

// using Microsoft.Extensions.DependencyInjection.ConfigSample.Options

var builder = WebApplication.CreateBuilder(args);

// Configure logging..
if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddConsole();
}

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();

//Add App Services
builder.Services.AddSingleton<IPluginManager, PluginManager>();

builder.Services.AddSingleton<ISteamGamesService, SteamGamesService>();
builder.Services.AddSingleton<ISettings, Settings>();
builder.Services.AddSingleton<INexusAPIManager, NexusAPIManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
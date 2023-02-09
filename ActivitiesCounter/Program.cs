using ActivitiesCounter;
using ActivitiesCounter.Managers;
using ActivitiesCounter.Repositories;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Modal;
using Havit.Blazor.Components.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();
builder.Services.AddHxServices();

builder.Services.AddScoped<IFilesManager, FilesManager>();
builder.Services.AddScoped<IActivitiesManager, ActivitiesManager>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

var host =  builder.Build();

var filesManager = host.Services.GetRequiredService<IFilesManager>();
filesManager.LoadFilesData();

await host.RunAsync();

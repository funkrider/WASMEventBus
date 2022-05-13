using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WASMEventBus.Client;
using WASMEventBus.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Bus services
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<PublisherGateway>();
builder.Services.AddTransient<IBus, RemotableBus>();
 
//"RemoteBusUrl": "https://localhost:7280"
var url = builder.Configuration["RemoteBusUrl"];
Console.WriteLine(url);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7280/api/") });

// end bus services

await builder.Build().RunAsync();
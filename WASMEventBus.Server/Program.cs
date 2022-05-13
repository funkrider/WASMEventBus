using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WASMEventBus.Server.Data;
using WASMEventBus.Shared;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                //WithOrigins("https://localhost:44398")
                policy.AllowAnyOrigin()
                    //.WithOrigins("https://localhost:44398")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    }); 

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddSingleton<WeatherForecastService>();

// Bus services
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IBus, Bus>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(o => true));

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


using WebApplication6.Hubs;
using WebApplication6.Services;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<CurrencyService>();

builder.Services.AddSignalR(); // Додавання SignalR
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<CurrencyHub>("/currencyHub");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.Run();

using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;
using WebApplication4.Services.Implementations;
using WebApplication4.Services.Interfaces;
using WebApplication4.Services.Health;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Optivem.Framework.Core.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using HealthChecks.UI.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<MyHealthCheckService>();


builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "project", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter the JWT authorization token.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                    },
                    Array.Empty<string>() }
            });
});




// Зчитуємо налаштування JWT з appsettings.json

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Отримання секції конфігурації JwtSettings
var jwtConfig = configuration.GetSection("JwtSettings");
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        
        options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig["Issuer"],
            ValidAudience = jwtConfig["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]!))
        };
    });

builder.Services.AddHealthChecks()
.AddCheck("example", new MyHealthCheckService())
.AddCheck("db", new MyHealthCheckService());
builder.Services.AddHealthChecks()
           .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), name: "db");
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/healthExample", new HealthCheckOptions
{
    Predicate = (check) => check.Tags.Contains("example"),
});
app.UseHealthChecks("/healthDB", new HealthCheckOptions
{
    Predicate = (check) => check.Tags.Contains("db"),
});
//Власний кастомний письменник відповіді
app.MapHealthChecks("/health", new HealthCheckOptions
 {
     ResponseWriter = CustomHealthCheckResponseWriter.WriteResponse
 });
//task 5 для графічного представлення стану HealthCheck
app.UseHealthChecksUI(options =>
{
    options.UIPath = "/healthui";
});


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

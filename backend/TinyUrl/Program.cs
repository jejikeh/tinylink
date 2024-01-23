using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using TinyUrl.Common.Models;

var testLocalHostFrontend = "_testLocalHostFrontend";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(testLocalHostFrontend, policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie");

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors(testLocalHostFrontend);

// app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

var api = app.MapGroup("/api");

api.MapGet("/user", (ClaimsPrincipal user) =>
{
    return user.Claims.Select(c => new { c.Type, c.Value });
});
api.MapPost("/login", (LoginForm loginForm) =>
{
    return Results.SignIn(
        new ClaimsPrincipal(
            new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(Claims.Id, Guid.NewGuid().ToString()), 
                    new Claim(Claims.Email, loginForm.Email),
                    new Claim(Claims.Username, loginForm.Username)
                },
                "cookie"
            )),
        properties: new AuthenticationProperties()
        {
            IsPersistent = true
        },
        authenticationScheme: "cookie");
});

api.MapPost("/register", () => "Hello, world");
api.MapPost("/logout", () => Results.SignOut(authenticationSchemes: ["cookie"])).RequireAuthorization();

app.Run();

public class LoginForm
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}
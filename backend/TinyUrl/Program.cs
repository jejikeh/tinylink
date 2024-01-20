using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using TinyUrl.Common.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie");

builder.Services.AddAuthorization();

var app = builder.Build();

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
    Results.SignIn(
        new ClaimsPrincipal(
            new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(Claims.Id, Guid.NewGuid().ToString()), 
                    new Claim(Claims.Name, loginForm.Username),
                }
            )),
        properties: new AuthenticationProperties()
        {
            IsPersistent = true
        },
        authenticationScheme: "Cookie");
});

api.MapPost("/register", () => "Hello, world");
api.MapGet("/logout", () => Results.SignOut(authenticationSchemes: ["Cookie"])).RequireAuthorization();
api.MapPost("test", () => new
{
    Result = "Hello, world"
});

app.Run();

public class LoginForm
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
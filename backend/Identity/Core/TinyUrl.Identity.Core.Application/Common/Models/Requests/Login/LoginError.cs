using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models.Requests.Login;

public class LoginError(string message, int statusCode) : Error(message, statusCode)
{
    public static LoginError InvalidCredentials() 
        => new("Invalid credentials", 401);
    
    public static LoginError EmailIsNotConfirmed()
        => new("Email is not confirmed", 401);
}
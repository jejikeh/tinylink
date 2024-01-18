using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models.Requests.Register;

public class RegisterError(string message, int statusCode) : Error(message, statusCode)
{
    public static RegisterError UserAlreadyExists(string email, string id)
        => new($"User with email '{email}:{id}' already exists", 409);
    
    public static RegisterError InvalidCredentials()
        => new("Invalid credentials", 401);
}
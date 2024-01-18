using TinyUrl.Identity.Core.Application.Common.Types;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models.Services;

public class UserPasswordServiceError(string message, int statusCode) : Error(message, statusCode)
{
    public static UserPasswordServiceError InvalidPassword() 
        => new("Invalid password", ResultCodes.Unauthorized);
}
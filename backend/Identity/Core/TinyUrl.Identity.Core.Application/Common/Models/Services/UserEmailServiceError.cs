using TinyUrl.Identity.Core.Application.Common.Types;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models.Services;

public class UserEmailServiceError(string message, int statusCode) : Error(message, statusCode)
{
    public static UserEmailServiceError InvalidEmail()
        => new("Invalid email", ResultCodes.BadRequest);
    
    public static UserEmailServiceError InvalidToken()
        => new("Invalid token", ResultCodes.Unauthorized);
}
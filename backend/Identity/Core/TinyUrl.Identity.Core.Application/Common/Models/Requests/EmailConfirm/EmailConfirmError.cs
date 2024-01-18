using TinyUrl.Identity.Core.Application.Common.Types;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models.Requests.EmailConfirm;

public class EmailConfirmError(string message) : Error(message, ResultCodes.Unauthorized)
{
    public static EmailConfirmError InvalidToken()
        => new("Invalid token");
    
    public static EmailConfirmError UserAlreadyConfirmed()
        => new("User already confirmed");
    
    public static EmailConfirmError UserWithEmailNotFound(string email)
        => new($"User with email '{email}' not found");
}
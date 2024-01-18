using TinyUrl.Identity.Core.Application.Common.Types;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models.Services;

public class UserRepositoryError(string message, int statusCode) : Error(message, statusCode)
{
    public static UserRepositoryError UserNotFoundByEmail(string email)
        => new($"User with email '{email}' not found", ResultCodes.NotFound);
    
    public static UserRepositoryError UserNotFoundById(string id)
        => new($"User with id '{id}' not found", ResultCodes.NotFound);
    
    public static UserRepositoryError UserAlreadyExists(string email, string id)
        => new($"User with email '{email}:{id}' already exists", ResultCodes.Conflict);
}
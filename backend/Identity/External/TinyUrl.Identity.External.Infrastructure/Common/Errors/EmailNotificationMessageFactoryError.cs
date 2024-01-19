using TinyUrl.Identity.Core.Application.Common.Models.Services;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.External.Infrastructure.Common.Errors;

public class EmailNotificationMessageFactoryError(string message, int code) : Error(message, code)
{
    public static EmailNotificationMessageFactoryError FromUserEmailService(UserEmailServiceError userEmailServiceError) 
        => new(userEmailServiceError.Message, userEmailServiceError.StatusCode);
    
}
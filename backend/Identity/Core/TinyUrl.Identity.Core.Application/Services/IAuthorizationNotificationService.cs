using TinyUrl.Identity.Core.Application.Common.Models.Services;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Services;

public interface IAuthorizationNotificationService
{
    public Task<Result<Success, NotificationError>> SendConfirmationEmailToUserAsync(
        User user, 
        CancellationToken cancellationToken);
}
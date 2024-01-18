using TinyUrl.Identity.Core.Application.Common.Models.Services;
using TinyUrl.Identity.Core.Application.Services;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.External.Infrastructure.Services.Implementations.Notifications;

public class EmailAuthorizationNotificationService : IAuthorizationNotificationService
{
    public Task<Result<Success, IdentityNotificationError>> SendConfirmationEmailToUserAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
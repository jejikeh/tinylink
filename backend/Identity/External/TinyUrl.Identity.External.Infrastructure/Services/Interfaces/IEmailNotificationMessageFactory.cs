using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.Core.Domain.Types;
using TinyUrl.Identity.External.Infrastructure.Common.Errors;
using TinyUrl.Identity.External.Infrastructure.Common.Models.Notifications;

namespace TinyUrl.Identity.External.Infrastructure.Services.Interfaces;

public interface IEmailNotificationMessageFactory
{
    public Task<Result<IEmailNotification, EmailNotificationMessageFactoryError>> CreateConfirmNotificationAsync(
        User user, 
        CancellationToken cancellationToken);
}
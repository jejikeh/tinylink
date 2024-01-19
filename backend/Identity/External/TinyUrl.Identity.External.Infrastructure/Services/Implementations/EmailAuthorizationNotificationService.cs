using TinyUrl.Identity.Core.Application.Common.Models.Services;
using TinyUrl.Identity.Core.Application.Services;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.Core.Domain.Types;
using TinyUrl.Identity.External.Infrastructure.Common;
using TinyUrl.Identity.External.Infrastructure.Common.Models.Configuration;

namespace TinyUrl.Identity.External.Infrastructure.Services.Implementations;

public class EmailAuthorizationNotificationService(
    SmtpClientService smtpClientService,
    IIdentityInfrastructureConfiguration configuration)
    : IAuthorizationNotificationService
{
    private readonly EmailConfiguration _emailConfiguration = configuration.EmailConfiguration;
    
    public Task<Result<Success, NotificationError>> SendConfirmationEmailToUserAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
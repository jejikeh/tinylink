using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using TinyUrl.Identity.Core.Application.Services.UserIdentity;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.Core.Domain.Types;
using TinyUrl.Identity.External.Infrastructure.Common;
using TinyUrl.Identity.External.Infrastructure.Common.Errors;
using TinyUrl.Identity.External.Infrastructure.Common.Models.Notifications;
using TinyUrl.Identity.External.Infrastructure.Services.Interfaces;

namespace TinyUrl.Identity.External.Infrastructure.Services.Implementations;

public class EmailNotificationMessageFactory(
    IIdentityInfrastructureConfiguration configuration,
    IUserEmailService userEmailService) : IEmailNotificationMessageFactory
{
    public async Task<Result<IEmailNotification, EmailNotificationMessageFactoryError>> CreateConfirmNotificationAsync(User user, CancellationToken cancellationToken)
    {
        var emailConfirmationToken = await userEmailService.CreateConfirmationToken(user, cancellationToken);
        if (emailConfirmationToken.IsError)
        {
            return EmailNotificationMessageFactoryError
                .FromUserEmailService(emailConfirmationToken.GetError());
        }

        var token = Encoding.UTF8.GetBytes(emailConfirmationToken.GetValue());
        var encodedToken = WebEncoders.Base64UrlEncode(token);
        
        return new ConfirmEmailNotification(
            "Confirm your email",
            user.Email!,
            "Confirm your email",
            $"{configuration.UrlHost}/api/user/confirm-email?Id={user.Id}&Token={encodedToken}");
    }
}
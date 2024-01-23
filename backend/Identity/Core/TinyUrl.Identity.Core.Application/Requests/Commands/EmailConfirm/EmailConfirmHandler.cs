using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using TinyUrl.Identity.Core.Application.Common.Models.Requests.EmailConfirm;
using TinyUrl.Identity.Core.Application.Common.Models.Requests.Login;
using TinyUrl.Identity.Core.Application.Common.Types;
using TinyUrl.Identity.Core.Application.Services;
using TinyUrl.Identity.Core.Application.Services.UserIdentity;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Requests.Commands.EmailConfirm;

public class EmailConfirmHandler(
    IUserRepository userRepository,
    IUserEmailService userEmailService,
    ILoginTokenProvider loginTokenProvider)
    : IHandler<EmailConfirmRequest, LoginSuccess, EmailConfirmError>
{
    public async Task<Result<LoginSuccess, EmailConfirmError>> Handle(EmailConfirmRequest request, CancellationToken cancellationToken)
    {
        var getUserResult = await userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (getUserResult.IsError)
        {
            return EmailConfirmError.UserWithEmailNotFound(request.Email);
        }
        
        var user = getUserResult.GetValue();
        if (user.EmailConfirmed)
        {
            return EmailConfirmError.UserAlreadyConfirmed();
        }

        var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));
        var tryConfirmEmail = await userEmailService.ConfirmEmailAsync(user, decodedToken, cancellationToken);
        if (tryConfirmEmail.IsError)
        {
            return EmailConfirmError.InvalidToken();
        }
        
        var loginToken = await loginTokenProvider.GenerateLoginTokenAsync(user, cancellationToken);
        
        return new LoginSuccess(loginToken);
    }
}
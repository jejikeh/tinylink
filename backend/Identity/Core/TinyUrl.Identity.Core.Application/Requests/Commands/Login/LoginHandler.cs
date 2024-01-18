using TinyUrl.Identity.Core.Application.Common.Models.Requests.Login;
using TinyUrl.Identity.Core.Application.Common.Types;
using TinyUrl.Identity.Core.Application.Services;
using TinyUrl.Identity.Core.Application.Services.UserIdentity;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Requests.Commands.Login;

public class LoginHandler(
    IUserRepository userRepository, 
    IUserPasswordService userPasswordService,
    ILoginTokenProvider loginTokenProvider)
    : IHandler<LoginRequest, LoginSuccess, LoginError>
{
    public async Task<Result<LoginSuccess, LoginError>> Handle(
        LoginRequest request, 
        CancellationToken cancellationToken)
    {
        var getUserResult = await userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (getUserResult.IsError)
        {
            return LoginError.InvalidCredentials();
        }
        
        var user = getUserResult.GetValue();
        
        var isPasswordValidResult = await userPasswordService.CheckPasswordAsync(
            user, 
            request.Password,
            cancellationToken);
        
        if (isPasswordValidResult.IsError)
        {
            return LoginError.InvalidCredentials();
        }

        var loginToken = await loginTokenProvider.GenerateLoginTokenAsync(user, cancellationToken);
        
        return new LoginSuccess(loginToken);
    }
}
using TinyUrl.Identity.Core.Application.Common;
using TinyUrl.Identity.Core.Application.Common.Models.Configuration;
using TinyUrl.Identity.Core.Application.Common.Models.Requests.Register;
using TinyUrl.Identity.Core.Application.Common.Types;
using TinyUrl.Identity.Core.Application.Services;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Requests.Commands.Register;

public class RegisterHandler(
        IIdentityApplicationConfiguration configuration,
        IUserRepository userRepository,
        IIdentityNotificationService notificationService,
        ILoginTokenProvider loginTokenProvider
    ) : IHandler<RegisterRequest, RegisterSuccess, RegisterError>
{
    private readonly RegistrationConfiguration _registrationConfiguration = configuration.Registration;
    
    public async Task<Result<RegisterSuccess, RegisterError>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var createUserResult = await userRepository.CreateAsync(
            new User(request.Name, request.Email),
            cancellationToken);

        if (createUserResult.IsError)
        {
            return RegisterError.InvalidCredentials();
        }
        
        var user = createUserResult.GetValue();

        if (_registrationConfiguration.RequireEmailConfirmation)
        {
            var result = await notificationService.SendConfirmationEmailToUserAsync(user, cancellationToken);
            if (result.IsError)
            {
                return RegisterError.InvalidCredentials();
            }
            
            return RegisterSuccess.EmailConfirmationRequired(request.Email);
        }
        
        var loginToken = await loginTokenProvider.GenerateLoginTokenAsync(user, cancellationToken);
        
        return RegisterSuccess.Ok(loginToken);
    }
}
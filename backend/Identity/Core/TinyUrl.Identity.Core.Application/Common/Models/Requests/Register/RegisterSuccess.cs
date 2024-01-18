using TinyUrl.Identity.Core.Application.Common.Types;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models.Requests.Register;

public class RegisterSuccess(string message) : Success(message, ResultCodes.Created)
{
    public LoginToken? LoginToken { get; set; }
    
    public static RegisterSuccess EmailConfirmationRequired(string email) 
        => new($"Email confirmation required for '{email}'");
    
    public static RegisterSuccess Ok(LoginToken loginToken) 
        => new("Registration successful") { LoginToken = loginToken };
}
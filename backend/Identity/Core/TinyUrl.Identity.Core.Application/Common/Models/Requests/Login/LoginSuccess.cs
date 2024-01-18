using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models.Requests.Login;

public class LoginSuccess(LoginToken loginToken) : Success("Successfully logged in")
{
    public LoginToken LoginToken { get; set; } = loginToken;
}
using TinyUrl.Identity.Core.Application.Common.Models.Requests.Login;
using TinyUrl.Identity.Core.Application.Common.Types;

namespace TinyUrl.Identity.Core.Application.Requests.Commands.Login;

public class LoginRequest : IResultRequest<LoginSuccess, LoginError>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
using TinyUrl.Identity.Core.Application.Common.Models.Requests.EmailConfirm;
using TinyUrl.Identity.Core.Application.Common.Models.Requests.Login;
using TinyUrl.Identity.Core.Application.Common.Types;

namespace TinyUrl.Identity.Core.Application.Requests.Commands.EmailConfirm;

public class EmailConfirmRequest : IResultRequest<LoginSuccess, EmailConfirmError>
{
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
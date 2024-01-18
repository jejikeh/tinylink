using TinyUrl.Identity.Core.Application.Common.Models.Requests.Register;
using TinyUrl.Identity.Core.Application.Common.Types;

namespace TinyUrl.Identity.Core.Application.Requests.Commands.Register;

public class RegisterRequest : IResultRequest<RegisterSuccess, RegisterError>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
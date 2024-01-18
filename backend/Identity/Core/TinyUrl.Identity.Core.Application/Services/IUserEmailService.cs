using TinyUrl.Identity.Core.Application.Common.Models.Services;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Services;

public interface IUserEmailService
{
    public Task<Result<Success, UserEmailServiceError>> ConfirmEmailAsync(
        User user, 
        string token, 
        CancellationToken cancellationToken);
}
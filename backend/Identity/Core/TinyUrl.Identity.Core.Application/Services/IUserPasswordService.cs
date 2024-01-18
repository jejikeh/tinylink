using TinyUrl.Identity.Core.Application.Common.Models.Services;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Services;

public interface IUserPasswordService
{
    public Task<Result<bool, UserPasswordServiceError>> CheckPasswordAsync(
        User user, 
        string password,
        CancellationToken cancellationToken = default);
}
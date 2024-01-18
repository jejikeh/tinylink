using TinyUrl.Identity.Core.Application.Common.Models;
using TinyUrl.Identity.Core.Domain;

namespace TinyUrl.Identity.Core.Application.Services;

public interface ILoginTokenProvider
{
    public Task<LoginToken> GenerateLoginTokenAsync(
        User user, 
        CancellationToken cancellationToken = default);
}
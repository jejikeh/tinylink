using TinyUrl.Identity.Core.Application.Common;
using TinyUrl.Identity.Core.Application.Common.Models;
using TinyUrl.Identity.Core.Application.Services;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.External.Persistence.Services.Interfaces;

namespace TinyUrl.Identity.External.Persistence.Services.Implementations;

public class LoginTokenProvider(
    IRefreshTokenRepository tokenRepository,
    ) : ILoginTokenProvider
{
    public Task<LoginToken> GenerateLoginTokenAsync(User user, CancellationToken cancellationToken = default)
    {
        
    }

    private RefreshToken CreateRefreshToken(User user)
    {
        var refreshToken = new RefreshToken(
            user.Id, DateTime.UtcNow.AddSeconds())
    }
}
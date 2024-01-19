using TinyUrl.Identity.Core.Application.Common.Models;
using TinyUrl.Identity.Core.Application.Services;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.External.Infrastructure.Common;
using TinyUrl.Identity.External.Persistence.Services.Interfaces;

namespace TinyUrl.Identity.External.Infrastructure.Services.Implementations;

public class LoginTokenProvider(
    IRefreshTokenRepository refreshTokenRepository,
    IAccessTokenProvider accessTokenProvider, 
    IIdentityInfrastructureConfiguration configuration) 
    : ILoginTokenProvider
{
    public async Task<LoginToken> GenerateLoginTokenAsync(User user, CancellationToken cancellationToken = default)
    {
        var refreshToken = GenerateRefreshToken(user, cancellationToken);
        await refreshTokenRepository.AddAsync(refreshToken, cancellationToken);

        var accessToken = accessTokenProvider.GenerateAccessToken(user);
        
        return new LoginToken(
            refreshToken.Content,
            accessToken,
            user.UserName ?? "unknown",
            user.Email ?? "unknown",
            user.Id);
    }

    private RefreshToken GenerateRefreshToken(User user, CancellationToken cancellationToken)
    {
        var refreshToken = new RefreshToken(
            user.Id, 
            DateTime.UtcNow.AddSeconds(configuration.Tokens.RefreshToken.Lifetime),
            configuration.Tokens.RefreshToken.ContentLength);
        
        refreshTokenRepository.AddAsync(refreshToken, cancellationToken);
        
        return refreshToken;
    }
}
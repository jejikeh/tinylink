using Microsoft.Extensions.Caching.Memory;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.External.Persistence.Services.Interfaces;

namespace TinyUrl.Identity.External.Persistence.Services.Implementations.InMemory;

public class RefreshTokenRepositoryInMemory(IMemoryCache memoryCache) : IRefreshTokenRepository
{
    public Task<RefreshToken?> AddAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default)
    {
        memoryCache.GetOrCreateAsync("ID/" + refreshToken.Id, _ => Task.FromResult(refreshToken));
        memoryCache.GetOrCreateAsync("TOKEN/" + refreshToken.Content, _ => Task.FromResult(refreshToken));
        
        return Task.FromResult<RefreshToken?>(refreshToken);
    }

    public Task<RefreshToken?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return memoryCache.GetOrCreateAsync("ID/" + id, _ => Task.FromResult<RefreshToken?>(null));
    }

    public Task<RefreshToken?> GetAsync(string token, CancellationToken cancellationToken = default)
    {
        return memoryCache.GetOrCreateAsync("TOKEN/" + token, _ => Task.FromResult<RefreshToken?>(null));
    }
}
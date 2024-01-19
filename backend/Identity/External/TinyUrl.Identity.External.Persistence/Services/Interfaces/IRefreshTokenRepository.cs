using TinyUrl.Identity.Core.Domain;

namespace TinyUrl.Identity.External.Persistence.Services.Interfaces;

public interface IRefreshTokenRepository
{
    public Task<RefreshToken?> AddAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default);
    public Task<RefreshToken?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<RefreshToken?> GetAsync(string token, CancellationToken cancellationToken = default);
}
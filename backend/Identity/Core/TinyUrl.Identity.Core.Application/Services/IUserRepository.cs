using TinyUrl.Identity.Core.Application.Common.Models.Services;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Services;

public interface IUserRepository
{
    public Task<Result<User, UserRepositoryError>> GetByEmailAsync(
        string email, 
        CancellationToken cancellationToken = default);
    
    public Task<Result<User, UserRepositoryError>> CreateAsync(
        User user, 
        CancellationToken cancellationToken = default);

    public Task<Result<User, UserRepositoryError>> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);
}
using TinyUrl.Identity.Core.Domain;

namespace TinyUrl.Identity.External.Infrastructure.Services.Interfaces;

public interface IJsonWebTokenProvider
{
    public string GenerateToken(User user);
}
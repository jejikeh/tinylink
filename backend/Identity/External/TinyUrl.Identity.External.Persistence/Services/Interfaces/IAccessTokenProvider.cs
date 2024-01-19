using TinyUrl.Identity.Core.Domain;

namespace TinyUrl.Identity.External.Persistence.Services.Interfaces;

public interface IAccessTokenProvider
{
    public string GenerateAccessToken(User user);
}
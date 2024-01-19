namespace TinyUrl.Identity.External.Persistence.Common;

public interface IIdentityPersistenceConfiguration
{
    public int RefreshTokenLifetime { get; }
}
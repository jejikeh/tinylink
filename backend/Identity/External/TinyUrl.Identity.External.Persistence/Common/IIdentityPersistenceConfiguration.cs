using TinyUrl.Identity.External.Persistence.Common.Models.Configuration;

namespace TinyUrl.Identity.External.Persistence.Common;

public interface IIdentityPersistenceConfiguration
{
    public DatabaseConfiguration Database { get; }
}
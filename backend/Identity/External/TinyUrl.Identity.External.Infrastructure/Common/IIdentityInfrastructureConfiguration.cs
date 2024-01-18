using TinyUrl.Identity.External.Infrastructure.Common.Models.Configuration;

namespace TinyUrl.Identity.External.Infrastructure.Common;

public interface IIdentityInfrastructureConfiguration
{
    public EmailConfiguration EmailConfiguration { get; }
    public RsaKeyConfiguration RsaKeyConfiguration { get; }
    public string UrlHost { get; }
}
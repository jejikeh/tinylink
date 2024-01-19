using TinyUrl.Identity.External.Infrastructure.Common.Models.Configuration;

namespace TinyUrl.Identity.External.Infrastructure.Common;

public interface IIdentityInfrastructureConfiguration
{
    public EmailConfiguration Email { get; }
    public RsaKeyConfiguration RsaKey { get; }
    public TokensConfiguration Tokens { get; }
    public string UrlHost { get; }
}
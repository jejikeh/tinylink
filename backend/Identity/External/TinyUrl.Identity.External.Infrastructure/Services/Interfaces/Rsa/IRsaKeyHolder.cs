using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace TinyUrl.Identity.External.Infrastructure.Services.Interfaces.Rsa;

public interface IRsaKeyHolder
{
    public RSA? RsaKey { get; }
    public RsaSecurityKey? RsaSecurityKey { get; }
    public void StoreRsaKey(RSA? rsaKey);
}
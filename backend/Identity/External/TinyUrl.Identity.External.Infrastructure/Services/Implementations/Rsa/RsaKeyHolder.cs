using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using TinyUrl.Identity.External.Infrastructure.Services.Interfaces.Rsa;

namespace TinyUrl.Identity.External.Infrastructure.Services.Implementations.Rsa;

public class RsaKeyHolder : IRsaKeyHolder
{
    public RSA? RsaKey { get; private set; }
    public RsaSecurityKey? RsaSecurityKey { get; private set; }
    
    public void StoreRsaKey(RSA? rsaKey)
    {
        RsaKey = rsaKey;
        RsaSecurityKey = new RsaSecurityKey(rsaKey);
    }
}
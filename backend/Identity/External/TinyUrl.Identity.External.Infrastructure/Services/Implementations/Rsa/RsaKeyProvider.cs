using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using TinyUrl.Identity.External.Infrastructure.Common;
using TinyUrl.Identity.External.Infrastructure.Services.Interfaces.Rsa;

namespace TinyUrl.Identity.External.Infrastructure.Services.Implementations.Rsa;

public class RsaKeyProvider(IIdentityInfrastructureConfiguration configuration) 
    : IRsaKeyProvider
{
    private readonly string _rsaKeyPath = configuration.RsaKeyConfiguration.RsaKeyPath;
    
    public RSA CreateRsa()
    {
        var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(File.ReadAllBytes(_rsaKeyPath), out _);

        return rsa;
    }

    public void SaveKey()
    {
        var rsa = RSA.Create();
        var privateKey = rsa.ExportRSAPrivateKey();
        File.WriteAllBytes(_rsaKeyPath, privateKey);
    }

    public JsonWebKey GetJsonWebKey()
    {
        var publicKey = RSA.Create();
        publicKey.ImportRSAPublicKey(File.ReadAllBytes(_rsaKeyPath), out _);
        var key = new RsaSecurityKey(publicKey);

        return JsonWebKeyConverter.ConvertFromRSASecurityKey(key);
    }
}
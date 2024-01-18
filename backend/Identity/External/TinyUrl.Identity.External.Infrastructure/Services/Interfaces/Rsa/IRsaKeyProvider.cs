using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace TinyUrl.Identity.External.Infrastructure.Services.Interfaces.Rsa;

public interface IRsaKeyProvider
{
    public RSA CreateRsa();
    public void SaveKey();
    public JsonWebKey GetJsonWebKey();
}
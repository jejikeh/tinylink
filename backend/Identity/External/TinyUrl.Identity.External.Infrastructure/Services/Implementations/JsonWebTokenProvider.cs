using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using TinyUrl.Identity.Core.Domain;
using TinyUrl.Identity.External.Infrastructure.Common;
using TinyUrl.Identity.External.Infrastructure.Services.Interfaces;
using TinyUrl.Identity.External.Infrastructure.Services.Interfaces.Rsa;

namespace TinyUrl.Identity.External.Infrastructure.Services.Implementations;

public class JsonWebTokenProvider(
    IIdentityInfrastructureConfiguration configuration, 
    IRsaKeyHolder rsaKeyHolder)
    : IJsonWebTokenProvider
{
    private readonly string _urlHost = configuration.UrlHost;
    
    public string GenerateToken(User user)
    {
        var rsaKey = rsaKeyHolder.RsaSecurityKey ?? throw new InvalidOperationException("Rsa key not found");
        
        var handler = new JsonWebTokenHandler();
        var token = handler.CreateToken(
            new SecurityTokenDescriptor()
            {
                Issuer = _urlHost,
                SigningCredentials = new SigningCredentials(rsaKey, SecurityAlgorithms.RsaSha256),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName ?? string.Empty),
                })
            }
        );

        return token;
    }
}
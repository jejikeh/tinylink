namespace TinyUrl.Identity.External.Infrastructure.Common.Models.Configuration;

public class TokensConfiguration
{
    public class RefreshTokenConfiguration
    {
        /// <summary>
        /// Provided in seconds.
        /// </summary>
        public int Lifetime { get; } = 10;
        
        public int ContentLength { get; } = 10;
    }
    
    public RefreshTokenConfiguration RefreshToken { get; }
}
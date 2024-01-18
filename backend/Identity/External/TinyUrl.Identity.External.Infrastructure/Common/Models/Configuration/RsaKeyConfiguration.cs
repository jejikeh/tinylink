namespace TinyUrl.Identity.External.Infrastructure.Common.Models.Configuration;

public class RsaKeyConfiguration
{
    public bool UseRsaKey { get; set; }
    public string RsaKeyPath { get; set; } = string.Empty;
    public bool RegenerateOnStartup { get; set; }
}
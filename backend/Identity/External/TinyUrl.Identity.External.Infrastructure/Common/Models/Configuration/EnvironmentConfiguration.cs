namespace TinyUrl.Identity.External.Infrastructure.Common.Models.Configuration;

public enum Environment
{
    Development,
    Staging,
    Production
}

public class EnvironmentConfiguration
{
    public Environment Environment { get; set; }
}
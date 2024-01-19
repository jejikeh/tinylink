namespace TinyUrl.Identity.External.Infrastructure.Common.Models.Configuration;

public class EmailConfiguration
{
    public required string Host { get; set; }
    public required int Port { get; set; }
    public required string User { get; set; }
    public required string Password { get; set; }
    public required string From { get; set; }
}
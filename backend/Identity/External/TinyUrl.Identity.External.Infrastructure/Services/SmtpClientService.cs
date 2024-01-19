using MailKit.Net.Smtp;
using TinyUrl.Identity.External.Infrastructure.Common;
using TinyUrl.Identity.External.Infrastructure.Common.Models.Configuration;

namespace TinyUrl.Identity.External.Infrastructure.Services;

public class SmtpClientService(IIdentityInfrastructureConfiguration configuration) : SmtpClient
{
    private readonly EmailConfiguration _emailConfiguration = configuration.EmailConfiguration;

    public void Connect()
    {
        Connect(_emailConfiguration.Host, _emailConfiguration.Port, true);
        AuthenticationMechanisms.Add("XOAUTH2");
        Authenticate(_emailConfiguration.User, _emailConfiguration.Password);
    }
}
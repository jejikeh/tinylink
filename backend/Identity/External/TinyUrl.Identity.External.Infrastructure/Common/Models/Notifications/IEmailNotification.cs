namespace TinyUrl.Identity.External.Infrastructure.Common.Models.Notifications;

public interface IEmailNotification
{
    public string Subject { get; set; }
    public string Email { get; set; }
    public string Title { get; set; }
    public string GenerateHtmlMessage();
}
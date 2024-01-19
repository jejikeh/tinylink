namespace TinyUrl.Identity.External.Infrastructure.Common.Models.Notifications;

public class ConfirmEmailNotification(
    string subject, 
    string email, 
    string title, 
    string urlToken) : IEmailNotification
{
    public string Subject { get; set; } = subject;
    public string Email { get; set; } = email;
    public string Title { get; set; } = title;

    public string GenerateHtmlMessage()
    {
        return $"<h1>Confirm your email</h1>" + $"<a href=\"{urlToken}\">Confirm your email</a>";
    }
}
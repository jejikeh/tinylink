using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models;

public class LoginToken(
    string refreshToken,
    string accessToken,
    string userName,
    string email,
    Guid id)
{
    public string RefreshToken { get; set; } = refreshToken;
    public string AccessToken { get; set; } = accessToken;
    public string UserName { get; set; } = userName;
    public string Email { get; set; } = email;
    public Guid Id { get; set; } = id;
}
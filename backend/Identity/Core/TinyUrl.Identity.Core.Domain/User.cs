using Microsoft.AspNetCore.Identity;

namespace TinyUrl.Identity.Core.Domain;

public sealed class User : IdentityUser<Guid>
{
    public User(string userName, string email)
    {
        Id = new Guid();
        
        UserName = userName;
        NormalizedUserName = userName.ToUpper();
        
        Email = email;
        NormalizedEmail = email.ToUpper();
    }
}
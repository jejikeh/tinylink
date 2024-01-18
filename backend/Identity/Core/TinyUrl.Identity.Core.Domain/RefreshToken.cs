using TinyUrl.Identity.Core.Domain.Common;

namespace TinyUrl.Identity.Core.Domain;

public class RefreshToken(Guid ownerId, DateTime expiredAt)
{
    public Guid Id { get; set; } = new Guid();
    
    public Guid OwnerId { get; set; } = ownerId;
    public User Owner { get; set; } = null!;

    public string Content { get; } = Utils.GenerateStringByRandom(10);
    
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime ExpiredAt { get; } = expiredAt;
    
    public bool IsExpired => DateTime.Now > ExpiredAt;
}
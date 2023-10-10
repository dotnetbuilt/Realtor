using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class Link:Auditable
{
    public string Name { get; set; }
    public string Text { get; set; }

    public long UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}
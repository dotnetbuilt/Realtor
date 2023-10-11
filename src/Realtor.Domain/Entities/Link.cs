using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class Link:Auditable
{
    public string Name { get; set; }
    public string Text { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
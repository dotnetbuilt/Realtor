using System.Net.Mail;
using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class UserProfile:Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }

    public string Bio { get; set; }

    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public ICollection<Phone> Phones { get; set; }
    public ICollection<Link> Links { get; set; }
}
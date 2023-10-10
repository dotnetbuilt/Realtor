using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class CottageBlock:Auditable
{
    public long PropertyId { get; set; }
    public Property Property { get; set; }

    public ICollection<CottageBlockPart> CottageBlockParts { get; set; }

    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
    
    public long AddressId { get; set; }
    public Address Address { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
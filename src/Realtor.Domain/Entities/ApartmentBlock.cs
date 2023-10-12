using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class ApartmentBlock:Auditable
{
    public long PropertyId { get; set; }
    public Property Property { get; set; }
    public int NumberOfFloors { get; set; }
    public ICollection<ApartmentBlockPart> ApartmentBlockParts { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment? Attachment { get; set; }

    public long AddressId { get; set; }
    public Address Address { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
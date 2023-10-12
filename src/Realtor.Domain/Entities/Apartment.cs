using Realtor.Domain.Commons;
using Realtor.Domain.Enums;

namespace Realtor.Domain.Entities;

public class Apartment:Auditable
{
    public long PropertyId { get; set; }
    public Property Property { get; set; }

    public int NumberOfFloors { get; set; }
    public int Floor { get; set; }
    public int NumberOfRooms { get; set; }
    public int UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment? Attachment { get; set; }
    
    public long UserId { get; set; }
    public User User { get; set; }

    public long AddressId { get; set; }
    public Address Address { get; set; }
}
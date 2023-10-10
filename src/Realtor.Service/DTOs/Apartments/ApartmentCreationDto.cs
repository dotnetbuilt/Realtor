using Realtor.Domain.Entities;
using Realtor.Domain.Enums;

namespace Realtor.Service.DTOs.Apartments;

public class ApartmentCreationDto
{
    public long PropertyId { get; set; }
    public int NumberOfFloors { get; set; }
    public int Floor { get; set; }
    public int NumberOfRooms { get; set; }
    public int UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
    public long UserId { get; set; }
    public long AddressId { get; set; }
}
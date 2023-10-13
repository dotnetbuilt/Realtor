using Realtor.Domain.Enums;

namespace Realtor.Service.DTOs.Apartments;

public class ApartmentUpdateDto
{
    public long Id { get; set; }
    public int NumberOfFloors { get; set; }
    public int Floor { get; set; }
    public int NumberOfRooms { get; set; }
    public int UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public long? AttachmentId { get; set; }
    public long PropertyId { get; set; }
    public long UserId { get; set; }
    public long AddressId { get; set; }
}
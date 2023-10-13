using Realtor.Domain.Enums;

namespace Realtor.Service.DTOs.Cottages;

public class CottageUpdateDto
{
    public long Id { get; set; }
    public int NumberOfFloors { get; set; }
    public int NumberOfRooms { get; set; }
    public decimal Cost { get; set; }
    public Currency Currency { get; set; }
    public int TotalArea { get; set; }
    public AreaUnit TotalAreaUnit { get; set; }
    public int UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public long? AttachmentId { get; set; }
    public long PropertyId { get; set; }
    public long UserId { get; set; }
    public long AddressId { get; set; }
}
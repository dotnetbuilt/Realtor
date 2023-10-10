using Realtor.Domain.Entities;
using Realtor.Domain.Enums;

namespace Realtor.Service.DTOs.Cottages;

public class CottageCreationDto
{
    public Guid PropertyId { get; set; }
    public int NumberOfFloors { get; set; }
    public int NumberOfRooms { get; set; }
    public decimal Cost { get; set; }
    public Currency Currency { get; set; }
    public long TotalArea { get; set; }
    public AreaUnit TotalAreaUnit { get; set; }
    public long UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
    public Guid UserProfileId { get; set; }
    public Guid AddressId { get; set; }
}
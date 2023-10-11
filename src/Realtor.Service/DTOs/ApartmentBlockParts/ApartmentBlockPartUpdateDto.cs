using Realtor.Domain.Enums;

namespace Realtor.Service.DTOs.ApartmentBlockParts;

public class ApartmentBlockPartUpdateDto
{
    public long Id { get; set; }
    public int NumberOfRooms { get; set; }
    public int UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public decimal Cost { get; set; }
    public Currency Currency { get; set; }
    public long ApartmentBlockId { get; set; }
}
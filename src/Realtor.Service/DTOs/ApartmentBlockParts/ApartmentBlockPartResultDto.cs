using Realtor.Domain.Enums;
using Realtor.Service.DTOs.ApartmentBlocks;

namespace Realtor.Service.DTOs.ApartmentBlockParts;

public class ApartmentBlockPartResultDto
{
    public long Id { get; set; }
    public int NumberOfRooms { get; set; }
    public int UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public decimal Cost { get; set; }
    public Currency Currency { get; set; }
    public ApartmentBlockResultDto ApartmentBlockResultDto { get; set; }
}
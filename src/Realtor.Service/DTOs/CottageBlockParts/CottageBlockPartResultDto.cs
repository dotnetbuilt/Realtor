using Realtor.Domain.Enums;
using Realtor.Service.DTOs.CottageBlocks;

namespace Realtor.Service.DTOs.CottageBlockParts;

public class CottageBlockPartResultDto
{
    public long Id { get; set; }
    public int NumberOfFloors { get; set; }
    public int NumberOfRooms { get; set; }
    public long TotalArea { get; set; }
    public AreaUnit TotalAreaUnit { get; set; }
    public long UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public decimal Cost { get; set; }
    public Currency Currency { get; set; }
    public CottageBlockResultDto CottageBlockResultDto { get; set; }
}
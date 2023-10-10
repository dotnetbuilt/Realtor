using Realtor.Domain.Commons;
using Realtor.Domain.Enums;

namespace Realtor.Domain.Entities;

public class CottageBlockPart:Auditable
{
    public int NumberOfFloors { get; set; }
    public int NumberOfRooms { get; set; }
    public int TotalArea { get; set; }
    public AreaUnit TotalAreaUnit { get; set; }
    public int UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public decimal Cost { get; set; }
    public Currency Currency { get; set; }

    public long CottageBlockId { get; set; }
    public CottageBlock CottageBlock { get; set; }
}
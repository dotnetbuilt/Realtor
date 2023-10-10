using Realtor.Domain.Commons;
using Realtor.Domain.Enums;

namespace Realtor.Domain.Entities;

public class ApartmentBlockPart:Auditable
{
    public int NumberOfRooms { get; set; }
    public int UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public decimal Cost { get; set; }
    public Currency Currency { get; set; }

    public long ApartmentBlockId { get; set; }
    public ApartmentBlock ApartmentBlock { get; set; }
}
using Realtor.Domain.Enums;

namespace Realtor.Service.DTOs.CottageBlockParts;

public class CottageBlockPartCreationDto
{
        public int NumberOfFloors { get; set; }
        public int NumberOfRooms { get; set; }
        public long TotalArea { get; set; }
        public AreaUnit TotalAreaUnit { get; set; }
        public long UsageArea { get; set; }
        public AreaUnit UsageAreaUnit { get; set; }
        public decimal Cost { get; set; }
        public Currency Currency { get; set; }
}
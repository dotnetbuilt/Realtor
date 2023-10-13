using Realtor.Service.DTOs.ApartmentBlockParts;

namespace Realtor.Service.DTOs.ApartmentBlocks;

public class ApartmentBlockCreationDto
{
    public long PropertyId { get; set; }
    public int NumberOfFloors { get; set; }
    public ICollection<ApartmentBlockPartCreationDto> ApartmentBlockParts { get; set; }
    public long? AttachmetId { get; set; }
    public long AddressId { get; set; }
    public long UserId { get; set; }
}
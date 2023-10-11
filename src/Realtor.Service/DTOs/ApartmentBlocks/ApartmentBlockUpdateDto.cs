using Realtor.Domain.Entities;
using Realtor.Service.DTOs.ApartmentBlockParts;

namespace Realtor.Service.DTOs.ApartmentBlocks;

public class ApartmentBlockUpdateDto
{
    public long Id { get; set; }
    public long PropertyId { get; set; }
    public int NumberOfFloors { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
    public ICollection<ApartmentBlockPartUpdateDto> ApartmentBlockParts { get; set; }
    public long AddressId { get; set; }
    public long UserId { get; set; }
}
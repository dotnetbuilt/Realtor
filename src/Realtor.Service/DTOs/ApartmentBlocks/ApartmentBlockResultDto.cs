using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Addresses;
using Realtor.Service.DTOs.ApartmentBlockParts;
using Realtor.Service.DTOs.Properties;
using Realtor.Service.DTOs.Users;

namespace Realtor.Service.DTOs.ApartmentBlocks;

public class ApartmentBlockResultDto
{
    public long Id { get; set; }
    public PropertyResultDto PropertyResultDto { get; set; }
    public int NumberOfFloors { get; set; }
    public ICollection<ApartmentBlockPartResultDto> ApartmentBlockParts { get; set; }
    public Attachment? Attachment { get; set; }
    public AddressResultDto AddressResultDto { get; set; }
    public UserResultDto UserResultDto { get; set; }
}
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Addresses;
using Realtor.Service.DTOs.CottageBlockParts;
using Realtor.Service.DTOs.Properties;
using Realtor.Service.DTOs.Users;

namespace Realtor.Service.DTOs.CottageBlocks;

public class CottageBlockResultDto
{
    public long Id { get; set; }
    public ICollection<CottageBlockPartResultDto> CottageBlockParts { get; set; }
    public Attachment? Attachment { get; set; }
    public PropertyResultDto Property { get; set; }
    public AddressResultDto Address { get; set; }
    public UserResultDto User { get; set; }
}
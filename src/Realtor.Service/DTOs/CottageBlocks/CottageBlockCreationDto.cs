using Realtor.Domain.Entities;
using Realtor.Service.DTOs.CottageBlockParts;

namespace Realtor.Service.DTOs.CottageBlocks;

public class CottageBlockCreationDto
{
    public long PropertyId { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
    public ICollection<CottageBlockPartCreationDto> CottageBlockParts { get; set; }
    public long AddressId { get; set; }
    public long UserId { get; set; }
}
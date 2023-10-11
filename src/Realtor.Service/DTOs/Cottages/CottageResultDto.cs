using Realtor.Domain.Entities;
using Realtor.Domain.Enums;
using Realtor.Service.DTOs.Addresses;
using Realtor.Service.DTOs.Properties;
using Realtor.Service.DTOs.Users;

namespace Realtor.Service.DTOs.Cottages;

public class CottageResultDto
{
    public Guid Id { get; set; }
    public PropertyResultDto PropertyResultDto { get; set; }
    public int NumberOfFloors { get; set; }
    public int NumberOfRooms { get; set; }
    public decimal Cost { get; set; }
    public Currency Currency { get; set; }
    public long TotalArea { get; set; }
    public AreaUnit TotalAreaUnit { get; set; }
    public long UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
    public UserResultDto UserResultDto { get; set; }
    public AddressResultDto AddressResultDto { get; set; }
}
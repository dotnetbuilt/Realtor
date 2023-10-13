using Realtor.Domain.Entities;
using Realtor.Domain.Enums;
using Realtor.Service.DTOs.Addresses;
using Realtor.Service.DTOs.Properties;
using Realtor.Service.DTOs.Users;

namespace Realtor.Service.DTOs.Apartments;

public class ApartmentResultDto
{
    public long Id { get; set; }
    public int NumberOfFloors { get; set; }
    public int Floor { get; set; }
    public int NumberOfRooms { get; set; }
    public int UsageArea { get; set; }
    public AreaUnit UsageAreaUnit { get; set; }
    public Attachment? Attachment { get; set; }
    public PropertyResultDto PropertyResultDto { get; set; }
    public UserResultDto UserResultDto { get; set; }
    public AddressResultDto AddressResultDto { get; set; }
}
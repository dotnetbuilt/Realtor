namespace Realtor.Service.DTOs.Addresses;

public class AddressCreationDto
{
    public long CountryId { get; set; }
    public long RegionId { get; set; }
    public long DistrictId { get; set; }
    public long NeighborhoodId { get; set; }
}
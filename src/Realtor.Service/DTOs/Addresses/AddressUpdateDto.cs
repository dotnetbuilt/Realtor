namespace Realtor.Service.DTOs.Addresses;

public class AddressUpdateDto
{
    public long Id { get; set; }
    public long CountryId { get; set; }
    public long RegionId { get; set; }
    public long DistrictId { get; set; }
    public long NeighborhoodId { get; set; }
}
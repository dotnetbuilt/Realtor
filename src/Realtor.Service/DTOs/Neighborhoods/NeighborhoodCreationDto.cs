namespace Realtor.Service.DTOs.Neighborhoods;

public class NeighborhoodCreationDto
{
    public string Name { get; set; }
    public long CountryId { get; set; }
    public long RegionId { get; set; }
    public long DistrictId { get; set; }
}
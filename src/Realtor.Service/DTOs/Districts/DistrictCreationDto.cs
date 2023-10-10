namespace Realtor.Service.DTOs.Districts;

public class DistrictCreationDto
{
    public string Name { get; set; }
    public long CountryId { get; set; }
    public long RegionId { get; set; }
}
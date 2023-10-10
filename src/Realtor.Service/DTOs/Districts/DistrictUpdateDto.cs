namespace Realtor.Service.DTOs.Districts;

public class DistrictUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CountryId { get; set; }
    public long RegionId { get; set; }
}
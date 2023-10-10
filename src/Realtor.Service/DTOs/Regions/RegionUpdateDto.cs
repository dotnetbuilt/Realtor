namespace Realtor.Service.DTOs.Regions;

public class RegionUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CountryId { get; set; }
}
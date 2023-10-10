namespace Realtor.Service.DTOs.Neighborhoods;

public class NeighborhoodUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CountryId { get; set; }
    public long RegionId { get; set; }
    public long DistrictId { get; set; }
}
using Realtor.Service.DTOs.Countries;
using Realtor.Service.DTOs.Districts;
using Realtor.Service.DTOs.Regions;

namespace Realtor.Service.DTOs.Neighborhoods;

public class NeighborhoodResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public CountryResultDto Country { get; set; }
    public RegionResultDto Region { get; set; }
    public DistrictResultDto District { get; set; }
}
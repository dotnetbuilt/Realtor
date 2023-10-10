using Realtor.Service.DTOs.Countries;
using Realtor.Service.DTOs.Regions;

namespace Realtor.Service.DTOs.Districts;

public class DistrictResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public CountryResultDto Country { get; set; }
    public RegionResultDto Region { get; set; }
}
using Realtor.Service.DTOs.Countries;
using Realtor.Service.DTOs.Districts;
using Realtor.Service.DTOs.Neighborhoods;
using Realtor.Service.DTOs.Regions;

namespace Realtor.Service.DTOs.Addresses;

public class AddressResultDto
{
    public long Id { get; set; }
    public CountryResultDto Country { get; set; }
    public RegionResultDto Region { get; set; }
    public DistrictResultDto District { get; set; }
    public NeighborhoodResultDto Neighborhood { get; set; }
}
using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class Neighborhood:Auditable
{
    public string Name { get; set; }

    public long CountryId { get; set; }
    public Country Country { get; set; }

    public long RegionId { get; set; }
    public Region Region { get; set; }

    public long DistrictId { get; set; }
    public District District { get; set; }
}
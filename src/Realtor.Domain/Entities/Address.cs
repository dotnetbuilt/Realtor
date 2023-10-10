using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class Address : Auditable
{
    public long CountryId { get; set; }
    public Country Country { get; set; }

    public long RegionId { get; set; }
    public Region Region { get; set; }

    public long DistrictId { get; set; }
    public District District { get; set; }

    public long NeighborhoodId { get; set; }
    public Neighborhood Neighborhood { get; set; }
}
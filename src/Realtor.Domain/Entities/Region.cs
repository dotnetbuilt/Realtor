using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class Region:Auditable
{
    public string Name { get; set; }

    public long CountryId { get; set; }
    public Country Country { get; set; }
}
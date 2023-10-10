using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class Country:Auditable
{
    public string Name { get; set; }
    public string Code { get; set; }
}
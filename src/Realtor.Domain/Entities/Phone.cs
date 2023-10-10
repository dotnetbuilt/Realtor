using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class Phone:Auditable
{
    public string Number { get; set; }

    public long UserProfileId { get; set; }
    public UserProfile Type { get; set; }
}
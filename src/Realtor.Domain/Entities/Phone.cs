using Realtor.Domain.Commons;

namespace Realtor.Domain.Entities;

public class Phone:Auditable
{
    public string Number { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
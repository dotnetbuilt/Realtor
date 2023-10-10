using Realtor.Domain.Entities;

namespace Realtor.Service.DTOs.UserProfiles;

public class UserProfileUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Bio { get; set; }
    public long AttachmentId { get; set; }
    public ICollection<Phone> Phones { get; set; }
    public ICollection<Link> Links { get; set; }    
}
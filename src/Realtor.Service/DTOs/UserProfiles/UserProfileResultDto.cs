using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Users;

namespace Realtor.Service.DTOs.UserProfiles;

public class UserProfileResultDto
{
    public long Id { get; set; }
    public UserResultDto UserResultDto { get; set; }
    public string Bio { get; set; }
    public Attachment AttachmentResultDto { get; set; }
    public ICollection<Phone> Phones { get; set; }
    public ICollection<Link> Links { get; set; }    
}
using Realtor.Service.DTOs.UserProfiles;

namespace Realtor.Service.DTOs.Phones;

public class PhoneResultDto
{
    public long Id { get; set; }
    public string Number { get; set; }
    public UserProfileResultDto UserProfileResultDto { get; set; }
}
using Realtor.Service.DTOs.UserProfiles;

namespace Realtor.Service.DTOs.Links;

public class LinkResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public UserProfileResultDto UserProfileResultDto { get; set; }
}
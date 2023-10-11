using Realtor.Service.DTOs.Users;

namespace Realtor.Service.DTOs.Links;

public class LinkResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public UserResultDto UserResultDto { get; set; }
}
namespace Realtor.Service.DTOs.Links;

public class LinkUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public long UserId { get; set; }
}
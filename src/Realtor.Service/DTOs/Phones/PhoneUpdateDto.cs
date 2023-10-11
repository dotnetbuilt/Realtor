namespace Realtor.Service.DTOs.Phones;

public class PhoneUpdateDto
{
    public long Id { get; set; }
    public string Number { get; set; }
    public long UserProfileId { get; set; }
}
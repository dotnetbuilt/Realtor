using Realtor.Service.DTOs.Users;

namespace Realtor.Service.DTOs.Phones;

public class PhoneResultDto
{
    public long Id { get; set; }
    public string Number { get; set; }
    public UserResultDto UserResultDto { get; set; }
}
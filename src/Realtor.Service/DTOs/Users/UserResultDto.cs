using Realtor.Domain.Enums;

namespace Realtor.Service.DTOs.Users;

public class UserResultDto
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role Role { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
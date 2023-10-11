using Realtor.Domain.Enums;

namespace Realtor.Service.DTOs.Users;

public class UserUpdateDto
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role Role { get; set; }
}
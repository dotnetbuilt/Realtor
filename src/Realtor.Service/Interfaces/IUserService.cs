using Realtor.Domain.Configurations;
using Realtor.Service.DTOs.Users;

namespace Realtor.Service.Interfaces;

public interface IUserService
{
        ValueTask<UserResultDto> AddAsync(UserCreationDto dto);
        ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto);
        ValueTask<bool> RemoveAsync(Guid id);
        ValueTask<bool> EraseAsync(Guid id);
        ValueTask<UserResultDto> RetrieveByIdAsync(Guid id);
        ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params);
        ValueTask<long> RetrieveNumberOfActiveUsers();
        ValueTask<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
}
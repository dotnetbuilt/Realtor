using Realtor.Domain.Configurations;
using Realtor.Service.DTOs.Users;

namespace Realtor.Service.Interfaces;

public interface IUserService
{     
        ValueTask<UserResultDto> AddAsync(UserCreationDto dto);
        ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto);
        ValueTask<bool> RemoveAsync(long id);
        ValueTask<bool> EraseAsync(long id);
        ValueTask<UserResultDto> RetrieveByIdAsync(long id);
        ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params);
        ValueTask<long> RetrieveNumberOfActiveUsers();
        ValueTask<bool> ChangePasswordAsync(long userId, string currentPassword, string newPassword);
}
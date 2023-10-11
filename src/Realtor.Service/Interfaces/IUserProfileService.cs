using Realtor.Service.DTOs.UserProfiles;

namespace Realtor.Service.Interfaces;

public interface IUserProfileService
{
    ValueTask<UserProfileResultDto> AddAsync(UserProfileCreationDto dto);
    ValueTask<UserProfileResultDto> ModifyAsync(UserProfileUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<UserProfileResultDto> RetrieveByIdAsync(long id);
}
using Realtor.Service.DTOs.Phones;

namespace Realtor.Service.Interfaces;

public interface IPhoneService
{
    ValueTask<PhoneResultDto> AddAsync(PhoneCreationDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<PhoneResultDto> RetrieveByIdAsync(long id);
}
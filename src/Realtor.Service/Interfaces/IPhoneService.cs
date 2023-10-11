using Realtor.Service.DTOs.Phones;

namespace Realtor.Service.Interfaces;

public interface IPhoneService
{
    ValueTask<PhoneResultDto> AddAsync(PhoneCreationDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<PhoneResultDto> RetrieveByIdAsync(Guid id);
}
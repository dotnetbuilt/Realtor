using Realtor.Service.DTOs.Addresses;

namespace Realtor.Service.Interfaces;

public interface IAddressService
{
    ValueTask<AddressResultDto> AddAsync(AddressCreationDto dto);
    ValueTask<AddressResultDto> ModifyAsync(AddressUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<bool> EraseAsync(long id);
    ValueTask<AddressResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<AddressResultDto>> RetrieveAllAsync();
}
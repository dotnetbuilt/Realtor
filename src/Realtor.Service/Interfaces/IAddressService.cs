using Realtor.Service.DTOs.Addresses;

namespace Realtor.Service.Interfaces;

public interface IAddressService
{
    ValueTask<AddressResultDto> AddAsync(AddressCreationDto dto);
    ValueTask<AddressResultDto> ModifyAsync(AddressUpdateDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<bool> EraseAsync(Guid id);
    ValueTask<AddressResultDto> RetrieveByIdAsync(Guid id);
    ValueTask<IEnumerable<AddressResultDto>> RetrieveAllAsync();
}
using Realtor.Service.DTOs.Properties;

namespace Realtor.Service.Interfaces;

public interface IPropertyService
{
    ValueTask<PropertyResultDto> AddAsync(PropertyCreationDto dto);
    ValueTask<PropertyResultDto> ModifyAsync(PropertyUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<PropertyResultDto> RetrieveByIdAsync(long id);
}
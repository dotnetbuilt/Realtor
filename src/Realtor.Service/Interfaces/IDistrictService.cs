using Realtor.Service.DTOs.Districts;

namespace Realtor.Service.Interfaces;

public interface IDistrictService
{
    ValueTask<DistrictResultDto> AddAsync(DistrictCreationDto dto);
    ValueTask<DistrictResultDto> ModifyAsync(DistrictUpdateDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<bool> EraseAsync(Guid id);
    ValueTask<DistrictResultDto> RetrieveByIdAsync(Guid id);
    ValueTask<IEnumerable<DistrictResultDto>> RetrieveAllAsync();
}
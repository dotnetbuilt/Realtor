using Realtor.Service.DTOs.Districts;

namespace Realtor.Service.Interfaces;

public interface IDistrictService
{
    ValueTask<DistrictResultDto> AddAsync(DistrictCreationDto dto);
    ValueTask<DistrictResultDto> ModifyAsync(DistrictUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<bool> EraseAsync(long id);
    ValueTask<DistrictResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<DistrictResultDto>> RetrieveAllAsync();
}
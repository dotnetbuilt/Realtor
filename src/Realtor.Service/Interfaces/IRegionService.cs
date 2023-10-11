using Realtor.Service.DTOs.Regions;

namespace Realtor.Service.Interfaces;

public interface IRegionService
{
    ValueTask<RegionResultDto> AddAsync(RegionCreationDto dto);
    ValueTask<RegionResultDto> ModifyAsync(RegionUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<bool> EraseAsync(long id);
    ValueTask<RegionResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<RegionResultDto>> RetrieveAllAsync();
}
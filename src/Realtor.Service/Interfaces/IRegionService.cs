using Realtor.Service.DTOs.Regions;

namespace Realtor.Service.Interfaces;

public interface IRegionService
{
    ValueTask<RegionResultDto> AddAsync(RegionCreationDto dto);
    ValueTask<RegionResultDto> ModifyAsync(RegionUpdateDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<bool> EraseAsync(Guid id);
    ValueTask<RegionResultDto> RetrieveByIdAsync(Guid id);
    ValueTask<IEnumerable<RegionResultDto>> RetrieveAllAsync();
}
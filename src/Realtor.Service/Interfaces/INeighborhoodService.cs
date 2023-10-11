using Realtor.Service.DTOs.Neighborhoods;

namespace Realtor.Service.Interfaces;

public interface INeighborhoodService
{
    ValueTask<NeighborhoodResultDto> AddAsync(NeighborhoodCreationDto dto);
    ValueTask<NeighborhoodResultDto> ModifyAsync(NeighborhoodUpdateDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<bool> EraseAsync(Guid id);
    ValueTask<NeighborhoodResultDto> RetrieveByIdAsync(Guid id);
    ValueTask<IEnumerable<NeighborhoodResultDto>> RetrieveAllAsync();
}
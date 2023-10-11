using Realtor.Service.DTOs.Neighborhoods;

namespace Realtor.Service.Interfaces;

public interface INeighborhoodService
{
    ValueTask<NeighborhoodResultDto> AddAsync(NeighborhoodCreationDto dto);
    ValueTask<NeighborhoodResultDto> ModifyAsync(NeighborhoodUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<bool> EraseAsync(long id);
    ValueTask<NeighborhoodResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<NeighborhoodResultDto>> RetrieveAllAsync();
}
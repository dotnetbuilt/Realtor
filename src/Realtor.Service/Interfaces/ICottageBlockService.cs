using Realtor.Service.DTOs.CottageBlocks;

namespace Realtor.Service.Interfaces;

public interface ICottageBlockService
{
    ValueTask<CottageBlockResultDto> AddAsync(CottageBlockCreationDto dto);
    ValueTask<CottageBlockResultDto> ModifyAsync(CottageBlockUpdateDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<CottageBlockResultDto> RetrieveByIdAsync(Guid id);
    ValueTask<IEnumerable<CottageBlockResultDto>> RetrieveAllByUserIdAsync(Guid userId);
}
using Realtor.Service.DTOs.CottageBlocks;

namespace Realtor.Service.Interfaces;

public interface ICottageBlockService
{
    ValueTask<CottageBlockResultDto> AddAsync(CottageBlockCreationDto dto);
    ValueTask<CottageBlockResultDto> ModifyAsync(CottageBlockUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<CottageBlockResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<CottageBlockResultDto>> RetrieveAllByUserIdAsync(long userId);
}
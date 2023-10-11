using Realtor.Service.DTOs.ApartmentBlocks;

namespace Realtor.Service.Interfaces;

public interface IApartmentBlockService
{
    ValueTask<ApartmentBlockResultDto> AddAsync(ApartmentBlockCreationDto dto);
    ValueTask<ApartmentBlockResultDto> ModifyAsync(ApartmentBlockUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<ApartmentBlockResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<ApartmentBlockResultDto>> RetrieveAllByUserIdAsync(long id);
}
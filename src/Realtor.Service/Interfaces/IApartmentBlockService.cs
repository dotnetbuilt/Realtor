using Realtor.Service.DTOs.ApartmentBlocks;

namespace Realtor.Service.Interfaces;

public interface IApartmentBlockService
{
    ValueTask<ApartmentBlockResultDto> AddAsync(ApartmentBlockCreationDto dto);
    ValueTask<ApartmentBlockResultDto> ModifyAsync(ApartmentBlockUpdateDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<ApartmentBlockResultDto> RetrieveByIdAsync(Guid id);
    ValueTask<IEnumerable<ApartmentBlockResultDto>> RetrieveAllByUserIdAsync(Guid id);
}
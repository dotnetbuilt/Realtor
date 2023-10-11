using Realtor.Service.DTOs.Cottages;

namespace Realtor.Service.Interfaces;

public interface ICottageService
{
    ValueTask<CottageResultDto> AddAsync(CottageCreationDto dto);
    ValueTask<CottageResultDto> ModifyAsync(CottageUpdateDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<CottageResultDto> RetrieveByIdAsync(Guid id);
    ValueTask<IEnumerable<CottageResultDto>> RetrieveAllByUserIdAsync(Guid userId);
}
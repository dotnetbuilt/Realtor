using Realtor.Service.DTOs.Cottages;

namespace Realtor.Service.Interfaces;

public interface ICottageService
{
    ValueTask<CottageResultDto> AddAsync(CottageCreationDto dto);
    ValueTask<CottageResultDto> ModifyAsync(CottageUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<CottageResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<CottageResultDto>> RetrieveAllByUserIdAsync(long userId);
}
using Realtor.Service.DTOs.CottageBlockParts;

namespace Realtor.Service.Interfaces;

public interface ICottageBlockPartService
{
    ValueTask<CottageBlockPartResultDto> AddAsync(CottageBlockPartCreationDto dto);
    ValueTask<CottageBlockPartResultDto> ModifyAsync(CottageBlockPartUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<CottageBlockPartResultDto> RetrieveByIdAsync(long id);
}
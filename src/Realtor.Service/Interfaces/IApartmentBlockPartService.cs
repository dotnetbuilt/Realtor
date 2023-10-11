using Realtor.Service.DTOs.ApartmentBlockParts;

namespace Realtor.Service.Interfaces;

public interface IApartmentBlockPartService
{
    ValueTask<ApartmentBlockPartResultDto> AddAsync(ApartmentBlockPartCreationDto dto);
    ValueTask<ApartmentBlockPartResultDto> ModifyAsync(ApartmentBlockPartUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<ApartmentBlockPartResultDto> RetrieveByIdAsync(long id);
}
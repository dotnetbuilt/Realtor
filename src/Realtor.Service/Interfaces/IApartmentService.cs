using Realtor.Service.DTOs.Apartments;

namespace Realtor.Service.Interfaces;

public interface IApartmentService
{
    ValueTask<ApartmentResultDto> AddAsync(ApartmentCreationDto dto);
    ValueTask<ApartmentResultDto> ModifyAsync(ApartmentUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<ApartmentResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<ApartmentResultDto>> RetrieveAllByUserIdAsync(long userId);
}
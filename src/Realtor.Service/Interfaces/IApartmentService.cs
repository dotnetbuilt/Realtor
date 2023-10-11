using Realtor.Service.DTOs.Apartments;

namespace Realtor.Service.Interfaces;

public interface IApartmentService
{
    ValueTask<ApartmentResultDto> AddAsync(ApartmentCreationDto dto);
    ValueTask<ApartmentResultDto> ModifyAsync(ApartmentUpdateDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<ApartmentResultDto> RetrieveByIdAsync(Guid id);
    ValueTask<IEnumerable<ApartmentResultDto>> RetrieveAllByUserIdAsync(Guid userId);
}
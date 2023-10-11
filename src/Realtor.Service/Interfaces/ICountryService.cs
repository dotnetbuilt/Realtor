using Realtor.Service.DTOs.Countries;

namespace Realtor.Service.Interfaces;

public interface ICountryService
{
    ValueTask<CountryResultDto> AddAsync(CountryCreationDto dto);
    ValueTask<CountryResultDto> ModifyAsync(CountryUpdateDto dto);
    ValueTask<bool> RemoveAsync(Guid id);
    ValueTask<bool> EraseAsync(Guid id);
    ValueTask<CountryResultDto> RetrieveByIdAsync(Guid id);
    ValueTask<IEnumerable<CountryResultDto>> RetrieveAllAsync();
}
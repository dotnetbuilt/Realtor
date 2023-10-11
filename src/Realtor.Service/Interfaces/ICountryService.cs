using Realtor.Service.DTOs.Countries;

namespace Realtor.Service.Interfaces;

public interface ICountryService
{
    ValueTask<CountryResultDto> AddAsync(CountryCreationDto dto);
    ValueTask<CountryResultDto> ModifyAsync(CountryUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<bool> EraseAsync(long id);
    ValueTask<CountryResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<CountryResultDto>> RetrieveAllAsync();
}
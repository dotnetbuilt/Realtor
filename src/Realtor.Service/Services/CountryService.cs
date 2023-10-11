using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Countries;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class CountryService:ICountryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CountryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<CountryResultDto> AddAsync(CountryCreationDto dto)
    {
        var existCountryByName = await _unitOfWork.CountryRepository
            .SelectAsync(expression:country => country.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase));
        
        if (existCountryByName != null)
            throw new AlreadyExistsException(message: "Country Name is already taken!");

        var existCountryByCode = await _unitOfWork.CountryRepository
            .SelectAsync(expression:country => country.Code.Equals(dto.Code, StringComparison.OrdinalIgnoreCase));

        if (existCountryByCode != null)
            throw new AlreadyExistsException(message: "Country Code is already taken!");

        var mappedCountry = _mapper.Map<Country>(source:dto);
        await _unitOfWork.CountryRepository.CreateAsync(entity:mappedCountry);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CountryResultDto>(source:mappedCountry);
    }

    public async ValueTask<CountryResultDto> ModifyAsync(CountryUpdateDto dto)
    {
        var existCountry =
            await _unitOfWork.CountryRepository.SelectAsync(expression:country =>
                country.IsDeleted == false && country.Id == dto.Id)
            ?? throw new NotFoundException(message: "Country is not found!");

        _mapper.Map(source:dto, destination:existCountry);
        _unitOfWork.CountryRepository.Update(entity:existCountry);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CountryResultDto>(source:existCountry);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existCountry =
            await _unitOfWork.CountryRepository.SelectAsync(expression:country =>
                country.IsDeleted == false && country.Id == id)
            ?? throw new NotFoundException(message: "Country is not found!");
        
        _unitOfWork.CountryRepository.Delete(entity:existCountry);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<bool> EraseAsync(long id)
    {
        var existCountry = await _unitOfWork.CountryRepository
                               .SelectAsync(expression:country => country.IsDeleted == false && country.Id == id)
                           ?? throw new NotFoundException(message: "Country is not found!");
        
        _unitOfWork.CountryRepository.Destroy(entity:existCountry);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<CountryResultDto> RetrieveByIdAsync(long id)
    {
        var existCountry = await _unitOfWork.CountryRepository
                               .SelectAsync(expression:country => country.IsDeleted == false && country.Id == id)
                           ?? throw new NotFoundException(message: "Country is not found!");

        return _mapper.Map<CountryResultDto>(source:existCountry);
    }
    
    public async ValueTask<IEnumerable<CountryResultDto>> RetrieveAllAsync()
    {
        var countries = await _unitOfWork.CountryRepository
            .SelectAll(expression:country=>country.IsDeleted==false).ToListAsync();

        return _mapper.Map<IEnumerable<CountryResultDto>>(source:countries);
    }
}
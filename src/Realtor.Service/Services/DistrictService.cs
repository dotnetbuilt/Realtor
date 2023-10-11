using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Districts;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class DistrictService:IDistrictService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DistrictService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<DistrictResultDto> AddAsync(DistrictCreationDto dto)
    {
        var existCountry = await _unitOfWork.CountryRepository
                               .SelectAsync(expression:country => country.Id == dto.CountryId)
                           ?? throw new NotFoundException(message: "Country is not found!");

        var existRegion = await _unitOfWork.RegionRepository
                              .SelectAsync(expression:region => region.Id == dto.RegionId,
                                  includes:new[]{"Region.Country"})
                          ?? throw new NotFoundException(message: "Region is not found!");

        var existDistrict = await _unitOfWork.DistrictRepository
            .SelectAsync(expression:district => district.Name.Equals(dto.Name),
                includes:new[]{"Region.Country"});

        if (existDistrict != null)
            throw new AlreadyExistsException(message: "Region Name is already taken!");

        var mappedDistrict = _mapper.Map<District>(source:dto);
        mappedDistrict.Country = existCountry;
        mappedDistrict.Region = existRegion;

        await _unitOfWork.DistrictRepository.CreateAsync(entity:mappedDistrict);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<DistrictResultDto>(source:mappedDistrict);
    }

    public async ValueTask<DistrictResultDto> ModifyAsync(DistrictUpdateDto dto)
    {
        var existDistrict = await _unitOfWork.DistrictRepository
                                .SelectAsync(expression:district => district.Id == dto.Id,includes:new[]{"Region.Country"})
                            ?? throw new NotFoundException(message: "District is not found!");

        _mapper.Map(source:dto,destination: existDistrict);
        
        _unitOfWork.DistrictRepository.Update(entity:existDistrict);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<DistrictResultDto>(source:existDistrict);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existDistrict = await _unitOfWork.DistrictRepository
                                .SelectAsync(expression:district => district.Id == id,
                                    includes:new[]{"Region.Country"})
                            ?? throw new NotFoundException(message: "District is not found!");
        
        _unitOfWork.DistrictRepository.Delete(entity:existDistrict);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<bool> EraseAsync(long id)
    {
        var existDistrict = await _unitOfWork.DistrictRepository
                                .SelectAsync(expression:district => district.Id == id ,
                                    includes:new[]{"Region.Country"})
                            ?? throw new NotFoundException(message: "District is not found!");
        
        _unitOfWork.DistrictRepository.Destroy(entity:existDistrict);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<DistrictResultDto> RetrieveByIdAsync(long id)
    {
        var existDistrict = await _unitOfWork.DistrictRepository
                                .SelectAsync(expression:district => district.Id == id ,
                                    includes:new[]{"Region.Country"})
                            ?? throw new NotFoundException(message: "District is not found!");

        return _mapper.Map<DistrictResultDto>(source:existDistrict);
    }

    public async ValueTask<IEnumerable<DistrictResultDto>> RetrieveAllAsync()
    {
        var districts = await _unitOfWork.DistrictRepository
            .SelectAll(includes:new[]{"Region.Country"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<DistrictResultDto>>(source:districts);
    }
}
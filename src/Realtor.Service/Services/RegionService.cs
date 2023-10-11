using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Regions;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class RegionService:IRegionService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RegionService(IMapper mapper,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<RegionResultDto> AddAsync(RegionCreationDto dto)
    {
        var existCountry = await _unitOfWork.CountryRepository
                               .SelectAsync(expression:country => country.Id == dto.CountryId)
                           ?? throw new NotFoundException(message: "Country is not found!");

        var existRegion = await _unitOfWork.RegionRepository
            .SelectAsync(expression:region => region.Name.Equals(dto.Name),
                includes:new[]{"Country"});
        
        if (existRegion != null)
            throw new AlreadyExistsException(message: "Region Name is already taken");

        var mappedRegion = _mapper.Map<Region>(source:dto);
        mappedRegion.Country = existCountry;

        await _unitOfWork.RegionRepository.CreateAsync(entity:mappedRegion);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<RegionResultDto>(source:mappedRegion);
    }

    public async ValueTask<RegionResultDto> ModifyAsync(RegionUpdateDto dto)
    {
        var existRegion = await _unitOfWork.RegionRepository
            .SelectAsync(expression:region => region.Id == dto.Id,includes:new[]{"Country"})
                          ?? throw new NotFoundException(message: "Region is not found!");

        var mappedRegion = _mapper.Map(source: dto, destination: existRegion);
        
        _unitOfWork.RegionRepository.Update(entity:mappedRegion);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<RegionResultDto>(source:mappedRegion);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existRegion = await _unitOfWork.RegionRepository
            .SelectAsync(expression:region => region.Id == id,includes:new[]{"Country"})
                          ?? throw new NotFoundException(message: "Region is not found!");
        
        _unitOfWork.RegionRepository.Delete(entity:existRegion);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<bool> EraseAsync(long id)
    {
        var existRegion = await _unitOfWork.RegionRepository
            .SelectAsync(expression:region => region.Id == id,includes:new[]{"Country"})
                          ?? throw new NotFoundException(message: "Region is not found!");
        
        _unitOfWork.RegionRepository.Destroy(entity:existRegion);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<RegionResultDto> RetrieveByIdAsync(long id)
    {
        var existRegion = await _unitOfWork.RegionRepository
            .SelectAsync(expression:region => region.Id == id,includes:new[]{"Country"})
                          ?? throw new NotFoundException(message: "Region is not found!");

        return _mapper.Map<RegionResultDto>(source:existRegion);
    }

    public async ValueTask<IEnumerable<RegionResultDto>> RetrieveAllAsync()
    {
        var regions = await _unitOfWork.RegionRepository
            .SelectAll(includes:new[]{"Country"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<RegionResultDto>>(source:regions);
    }
}
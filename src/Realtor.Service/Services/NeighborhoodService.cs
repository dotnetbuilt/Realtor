using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Neighborhoods;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class NeighborhoodService : INeighborhoodService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public NeighborhoodService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<NeighborhoodResultDto> AddAsync(NeighborhoodCreationDto dto)
    {
        var existCountry = await _unitOfWork.CountryRepository
                               .SelectAsync(expression: country =>country.Id == dto.CountryId)
                           ?? throw new NotFoundException(message: "CountryNotFound!");

        var existRegion = await _unitOfWork.RegionRepository
                              .SelectAsync(expression: region => region.Id == dto.RegionId &&
                                                                 region.CountryId == dto.CountryId,
                                  includes: new[] { "Country" })
                          ?? throw new NotFoundException(message: "RegionNotFound");

        var existDistrict = await _unitOfWork.DistrictRepository
                                .SelectAsync(expression: district => district.Id == dto.DistrictId &&
                                                                     district.RegionId == dto.RegionId &&
                                                                     district.CountryId == dto.CountryId,
                                    includes: new[] { "Region.Country" })
                            ?? throw new NotFoundException(message: "DistrictNotFound");

        var existNeighborhood = await _unitOfWork.NeighborhoodRepository.SelectAsync(
            expression: neighborhood => neighborhood.Name.Equals(dto.Name) &&
                                        neighborhood.DistrictId == dto.DistrictId &&
                                        neighborhood.RegionId == dto.RegionId &&
                                        neighborhood.CountryId == dto.CountryId,
            includes: new[] { "District.Region.Country" });

        if (existNeighborhood != null)
            throw new AlreadyExistsException(message: "NeighborhoodAlreadyExists");

        var mappedNeighborhood = _mapper.Map<Neighborhood>(dto);
        mappedNeighborhood.District = existDistrict;
        mappedNeighborhood.Region = existRegion;
        mappedNeighborhood.Country = existCountry;

        await _unitOfWork.NeighborhoodRepository.CreateAsync(entity: mappedNeighborhood);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<NeighborhoodResultDto>(source: mappedNeighborhood);
    }

    public async ValueTask<NeighborhoodResultDto> ModifyAsync(NeighborhoodUpdateDto dto)
    {
        var existNeighborhood = await _unitOfWork.NeighborhoodRepository
                                    .SelectAsync(expression: neighborhood => neighborhood.Id == dto.Id,
                                        includes: new[] { "District.Region.Country" })
                                ?? throw new NotFoundException(message: "NeighborhoodNotFound");

        _mapper.Map(source: dto, destination: existNeighborhood);

        _unitOfWork.NeighborhoodRepository.Update(entity: existNeighborhood);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<NeighborhoodResultDto>(source: existNeighborhood);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existNeighborhood = await _unitOfWork.NeighborhoodRepository
                                    .SelectAsync(expression: neighborhood => neighborhood.Id == id,
                                        includes: new[] { "District.Region.Country" })
                                ?? throw new NotFoundException(message: "NeighborhoodNotFound");

        _unitOfWork.NeighborhoodRepository.Delete(entity: existNeighborhood);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<bool> EraseAsync(long id)
    {
        var existNeighborhood = await _unitOfWork.NeighborhoodRepository
                                    .SelectAsync(expression: neighborhood => neighborhood.Id == id,
                                        includes: new[] { "District.Region.Country" })
                                ?? throw new NotFoundException(message: "NeighborhoodNotFound");

        _unitOfWork.NeighborhoodRepository.Destroy(entity: existNeighborhood);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<NeighborhoodResultDto> RetrieveByIdAsync(long id)
    {
        var existNeighborhood = await _unitOfWork.NeighborhoodRepository
                                    .SelectAsync(expression: neighborhood => neighborhood.Id == id,
                                        includes: new[] { "District.Region.Country" })
                                ?? throw new NotFoundException(message: "NeighborhoodNotFound");

        return _mapper.Map<NeighborhoodResultDto>(source: existNeighborhood);
    }

    public async ValueTask<IEnumerable<NeighborhoodResultDto>> RetrieveAllAsync()
    {
        var neighborhoods = await _unitOfWork.NeighborhoodRepository
            .SelectAll(includes: new[] { "District.Region.Country" })
            .ToListAsync();

        return _mapper.Map<IEnumerable<NeighborhoodResultDto>>(source: neighborhoods);
    }
}
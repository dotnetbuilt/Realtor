using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Addresses;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class AddressService:IAddressService
{
    
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddressService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<AddressResultDto> AddAsync(AddressCreationDto dto)
    {
        var existCountry =
            await _unitOfWork.CountryRepository.SelectAsync(expression: country => country.Id == dto.CountryId)
            ?? throw new NotFoundException(message: "CountryNotFound");

        var existRegion =
            await _unitOfWork.RegionRepository.SelectAsync(expression: region => region.Id == dto.RegionId,
                includes: new[] { "Country" })
            ?? throw new NotFoundException(message: "RegionNotFound");

        var existDistrict =
            await _unitOfWork.DistrictRepository.SelectAsync(expression: district => district.Id == dto.DistrictId,
                includes: new[] { "Region.Country","Country" })
            ?? throw new NotFoundException(message: "DistrictNotFound");

        var existNeighborhood = await _unitOfWork.NeighborhoodRepository.SelectAsync(
                                    expression: neighborhood => neighborhood.Id == dto.NeighborhoodId,
                                    includes: new[] { "District.Region.Country","Region.Country","Country" })
                                ?? throw new NotFoundException(message: "NeighborhoodNotFound");

        var mappedAddress = _mapper.Map<Address>(source: dto);
        mappedAddress.CountryId = existCountry.Id;
        mappedAddress.Country = existCountry;
        mappedAddress.RegionId = existRegion.Id;
        mappedAddress.Region = existRegion;
        mappedAddress.DistrictId = existDistrict.Id;
        mappedAddress.District = existDistrict;
        mappedAddress.NeighborhoodId = existNeighborhood.Id;
        mappedAddress.Neighborhood = existNeighborhood;

        await _unitOfWork.AddressRepository.CreateAsync(entity: mappedAddress);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<AddressResultDto>(source: mappedAddress);
    }

    public async ValueTask<AddressResultDto> ModifyAsync(AddressUpdateDto dto)
    {
        var existAddress = await _unitOfWork.AddressRepository.SelectAsync(expression: address => address.Id == dto.Id,
            includes: new[] 
                { "Neighborhood.District.Region.Country","District.Region.Country","Region.Country","Country" })
                           ?? throw new NotFoundException(message: "AddressNotFound");

        _mapper.Map(source: dto, destination: existAddress);

        _unitOfWork.AddressRepository.Update(entity: existAddress);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<AddressResultDto>(source: existAddress);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existAddress = await _unitOfWork.AddressRepository.SelectAsync(expression: address => address.Id == id,
            includes: new[] 
                { "Neighborhood.District.Region.Country","District.Region.Country","Region.Country","Country" })
                           ?? throw new NotFoundException(message: "AddressNotFound");
        
        _unitOfWork.AddressRepository.Delete(entity:existAddress);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<bool> EraseAsync(long id)
    {
        var existAddress = await _unitOfWork.AddressRepository.SelectAsync(expression: address => address.Id == id,
                               includes: new[] { "Neighborhood.District.Region.Country","District.Region.Country","Region.Country","Country" })
                           ?? throw new NotFoundException(message: "AddressNotFound");
        
        _unitOfWork.AddressRepository.Destroy(entity:existAddress);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<AddressResultDto> RetrieveByIdAsync(long id)
    {
        var existAddress = await _unitOfWork.AddressRepository.SelectAsync(expression: address => address.Id == id,
            includes: new[]
                { "Neighborhood.District.Region.Country" ,"District.Region.Country","Region.Country","Country"})
                           ?? throw new NotFoundException(message: "AddressNotFound");

        return _mapper.Map<AddressResultDto>(source: existAddress);
    }

    public async ValueTask<IEnumerable<AddressResultDto>> RetrieveAllAsync()
    {
        var addresses = await _unitOfWork.AddressRepository.SelectAll(
            includes:new[]{"Neighborhood.District.Region.Country" ,"District.Region.Country","Region.Country","Country"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<AddressResultDto>>(addresses);
    }
}
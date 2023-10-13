using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Apartments;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class ApartmentService:IApartmentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ApartmentService(IMapper mapper,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ApartmentResultDto> AddAsync(ApartmentCreationDto dto)
    {
        var existUser = await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.UserId)
                        ?? throw new NotFoundException(message: "User is not found");

        var existProperty =
            await _unitOfWork.PropertyRepository.SelectAsync(expression: property => property.Id == dto.PropertyId)
            ?? throw new NotFoundException(message: "Property is not found");

        var existAddress = await _unitOfWork.AddressRepository
            .SelectAsync(expression: address => address.Id == dto.AddressId,includes:
                new[]{"Neighborhood.District.Region.Country","District.Region.Country","Region.Country","Country"})
            ?? throw new NotFoundException(message: "Address is not found");
        
        var mappedApartment = _mapper.Map<Apartment>(source: dto);
        mappedApartment.AddressId = existAddress.Id;
        mappedApartment.Address = existAddress;
        mappedApartment.UserId = existUser.Id;
        mappedApartment.User = existUser;
        mappedApartment.PropertyId = existProperty.Id;
        mappedApartment.Property = existProperty;

        await _unitOfWork.ApartmentRepository.CreateAsync(entity: mappedApartment);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ApartmentResultDto>(source: mappedApartment);
    }

    public async ValueTask<ApartmentResultDto> ModifyAsync(ApartmentUpdateDto dto)
    {
        var existApartment = await _unitOfWork.ApartmentRepository
            .SelectAsync(expression:apartment => apartment.Id == dto.Id,
                includes:new[]{"User","Address","Property"});

        if (existApartment == null)
            throw new NotFoundException(message: "Apartment is not found");

        var mappedApartment = _mapper.Map(source: dto, destination: existApartment);
        
        _unitOfWork.ApartmentRepository.Update(entity:mappedApartment);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ApartmentResultDto>(source: mappedApartment);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existApartment = await _unitOfWork.ApartmentRepository
            .SelectAsync(expression:apartment => apartment.Id == id);

        if (existApartment == null)
            throw new NotFoundException(message: "Apartment is not found");
     
        _unitOfWork.ApartmentRepository.Delete(entity:existApartment);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<ApartmentResultDto> RetrieveByIdAsync(long id)
    {
        var existApartment = await _unitOfWork.ApartmentRepository
            .SelectAsync(expression:apartment => apartment.Id == id,
                includes:new[]{"User","Address","Property"});

        if (existApartment == null)
            throw new NotFoundException(message: "Apartment is not found");

        return _mapper.Map<ApartmentResultDto>(source: existApartment);
    }

    public async ValueTask<IEnumerable<ApartmentResultDto>> RetrieveAllByUserIdAsync(long userId)
    {
        var apartments = await _unitOfWork.ApartmentRepository
            .SelectAll(expression:apartment => apartment.UserId == userId,
                includes:new[]{"User","Address","Property"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<ApartmentResultDto>>(source: apartments);
    }
}
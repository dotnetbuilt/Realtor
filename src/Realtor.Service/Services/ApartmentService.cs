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
        var mappedApartment = _mapper.Map<Apartment>(source: dto);

        await _unitOfWork.ApartmentRepository.CreateAsync(entity: mappedApartment);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ApartmentResultDto>(source: mappedApartment);
    }

    public async ValueTask<ApartmentResultDto> ModifyAsync(ApartmentUpdateDto dto)
    {
        var existApartment = await _unitOfWork.ApartmentRepository
            .SelectAsync(apartment => apartment.Id == dto.Id);

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
            .SelectAsync(apartment => apartment.Id == id);

        if (existApartment == null)
            throw new NotFoundException(message: "Apartment is not found");
     
        _unitOfWork.ApartmentRepository.Delete(entity:existApartment);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<ApartmentResultDto> RetrieveByIdAsync(long id)
    {
        var existApartment = await _unitOfWork.ApartmentRepository
            .SelectAsync(expression:apartment => apartment.Id == id);

        if (existApartment == null)
            throw new NotFoundException(message: "Apartment is not found");

        return _mapper.Map<ApartmentResultDto>(source: existApartment);
    }

    public async ValueTask<IEnumerable<ApartmentResultDto>> RetrieveAllByUserIdAsync(long userId)
    {
        var apartments = await _unitOfWork.ApartmentRepository
            .SelectAll(expression:apartment => apartment.UserId == userId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ApartmentResultDto>>(source: apartments);
    }
}
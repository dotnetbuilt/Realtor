using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Cottages;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class CottageService:ICottageService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CottageService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<CottageResultDto> AddAsync(CottageCreationDto dto)
    {
        var existProperty =
            await _unitOfWork.PropertyRepository.SelectAsync(expression: property => property.Id == dto.PropertyId) ??
            throw new NotFoundException(message: "Property is not found");
        
        var existUser = await _unitOfWork.UserRepository.SelectAsync(expression: user => user.Id == dto.UserId) ??
                        throw new NotFoundException(message: "User is not found");

        var existAddress =
            await _unitOfWork.AddressRepository.SelectAsync(expression: address => address.Id == dto.AddressId) ??
            throw new NotFoundException(message: "Address is not found");
        
        var mappedCottage = _mapper.Map<Cottage>(source: dto);
        mappedCottage.UserId = existUser.Id;
        mappedCottage.User = existUser;
        mappedCottage.AddressId = existAddress.Id;
        mappedCottage.Address = existAddress;
        mappedCottage.PropertyId = existProperty.Id;
        mappedCottage.Property = existProperty;
        mappedCottage.AttachmentId = null;
        mappedCottage.Attachment = null;

        await _unitOfWork.CottageRepository.CreateAsync(entity: mappedCottage);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CottageResultDto>(source: mappedCottage);
    }

    public async ValueTask<CottageResultDto> ModifyAsync(CottageUpdateDto dto)
    {
        var existCottage =
            await _unitOfWork.CottageRepository.SelectAsync(expression:cottage => cottage.Id == dto.Id,
                includes:new [] {"Property","User","Address"});

        if (existCottage == null)
            throw new NotFoundException(message: "Cottage is not found");

        var mappedCottage = _mapper.Map(source: dto, destination: existCottage);
        
        _unitOfWork.CottageRepository.Update(entity:mappedCottage);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CottageResultDto>(source: mappedCottage);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existCottage =
            await _unitOfWork.CottageRepository.SelectAsync(expression:cottage => cottage.Id ==id,
                includes:new[]{"Property","User","Address"});

        if (existCottage == null)
            throw new NotFoundException(message: "Cottage is not found");
        
        _unitOfWork.CottageRepository.Delete(entity:existCottage);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<CottageResultDto> RetrieveByIdAsync(long id)
    {
        var existCottage =
            await _unitOfWork.CottageRepository.SelectAsync(expression:cottage => cottage.Id ==id,
                includes:new[]{"Property","User","Address"});

        if (existCottage == null)
            throw new NotFoundException(message: "Cottage is not found");

        return _mapper.Map<CottageResultDto>(source: existCottage);
    }

    public async ValueTask<IEnumerable<CottageResultDto>> RetrieveAllByUserIdAsync(long userId)
    {
        var cottages = await _unitOfWork.CottageRepository
            .SelectAll(cottage => cottage.UserId == userId,
                includes:new[]{"Property","User","Address"})
            .ToListAsync();

        return _mapper.Map<IEnumerable<CottageResultDto>>(source: cottages);
    }
}
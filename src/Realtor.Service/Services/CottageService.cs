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
        var mappedCottage = _mapper.Map<Cottage>(source: dto);

        await _unitOfWork.CottageRepository.CreateAsync(entity: mappedCottage);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CottageResultDto>(source: mappedCottage);
    }

    public async ValueTask<CottageResultDto> ModifyAsync(CottageUpdateDto dto)
    {
        var existCottage =
            await _unitOfWork.CottageRepository.SelectAsync(cottage => cottage.Id == dto.Id);

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
            await _unitOfWork.CottageRepository.SelectAsync(expression:cottage => cottage.Id ==id);

        if (existCottage == null)
            throw new NotFoundException(message: "Cottage is not found");
        
        _unitOfWork.CottageRepository.Delete(entity:existCottage);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<CottageResultDto> RetrieveByIdAsync(long id)
    {
        var existCottage =
            await _unitOfWork.CottageRepository.SelectAsync(expression:cottage => cottage.Id ==id);

        if (existCottage == null)
            throw new NotFoundException(message: "Cottage is not found");

        return _mapper.Map<CottageResultDto>(source: existCottage);
    }

    public async ValueTask<IEnumerable<CottageResultDto>> RetrieveAllByUserIdAsync(long userId)
    {
        var cottages = await _unitOfWork.CottageRepository
            .SelectAll(cottage => cottage.UserId == userId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CottageResultDto>>(source: cottages);
    }
}
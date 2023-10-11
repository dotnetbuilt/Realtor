using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.ApartmentBlocks;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class ApartmentBlockService:IApartmentBlockService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ApartmentBlockService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ApartmentBlockResultDto> AddAsync(ApartmentBlockCreationDto dto)
    {
        var mappedBlock = _mapper.Map<ApartmentBlock>(source: dto);

        await _unitOfWork.ApartmentBlockRepository.CreateAsync(entity: mappedBlock);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ApartmentBlockResultDto>(source: mappedBlock);
    }

    public async ValueTask<ApartmentBlockResultDto> ModifyAsync(ApartmentBlockUpdateDto dto)
    {
        var existBlock = 
            await _unitOfWork.ApartmentBlockRepository.SelectAsync(block => block.Id == dto.Id);

        if (existBlock == null)
            throw new NotFoundException(message: "ApartmentBlock is not found");

        var mappedBlock = _mapper.Map(source: dto, destination: existBlock);

        _unitOfWork.ApartmentBlockRepository.Update(entity:mappedBlock);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ApartmentBlockResultDto>(source: mappedBlock);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existBlock = 
            await _unitOfWork.ApartmentBlockRepository.SelectAsync(block => block.Id == id);

        if (existBlock == null)
            throw new NotFoundException(message: "ApartmentBlock is not found");
        
        _unitOfWork.ApartmentBlockRepository.Delete(entity:existBlock);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<ApartmentBlockResultDto> RetrieveByIdAsync(long id)
    {
        var existBlock = 
            await _unitOfWork.ApartmentBlockRepository.SelectAsync(block => block.Id == id);

        if (existBlock == null)
            throw new NotFoundException(message: "ApartmentBlock is not found");

        return _mapper.Map<ApartmentBlockResultDto>(source: existBlock);
    }

    public async ValueTask<IEnumerable<ApartmentBlockResultDto>> RetrieveAllByUserIdAsync(long id)
    {
        var blocks = await _unitOfWork.ApartmentBlockRepository
            .SelectAll(block => block.UserId == id)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ApartmentBlockResultDto>>(source: blocks);
    }
}
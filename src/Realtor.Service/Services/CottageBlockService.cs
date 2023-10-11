using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.CottageBlocks;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class CottageBlockService:ICottageBlockService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CottageBlockService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<CottageBlockResultDto> AddAsync(CottageBlockCreationDto dto)
    {
        var mappedBlock = _mapper.Map<CottageBlock>(source: dto);

        await _unitOfWork.CottageBlockRepository.CreateAsync(entity: mappedBlock);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CottageBlockResultDto>(source: mappedBlock);
    }

    public async ValueTask<CottageBlockResultDto> ModifyAsync(CottageBlockUpdateDto dto)
    {
        var existBlock = 
            await _unitOfWork.CottageBlockRepository.SelectAsync(expression:block => block.Id == dto.Id);

        if (existBlock == null)
            throw new NotFoundException(message: "CottageBlock is not found");

        var mappedBlock = _mapper.Map(source: dto, destination: existBlock);
        
        _unitOfWork.CottageBlockRepository.Update(entity:mappedBlock);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CottageBlockResultDto>(source: mappedBlock);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existBlock = 
            await _unitOfWork.CottageBlockRepository.SelectAsync(expression:block => block.Id == id);

        if (existBlock == null)
            throw new NotFoundException(message: "CottageBlock is not found");
        
        _unitOfWork.CottageBlockRepository.Delete(entity:existBlock);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<CottageBlockResultDto> RetrieveByIdAsync(long id)
    {
        var existBlock = 
            await _unitOfWork.CottageBlockRepository.SelectAsync(expression:block => block.Id == id);

        if (existBlock == null)
            throw new NotFoundException(message: "CottageBlock is not found");

        return _mapper.Map<CottageBlockResultDto>(source: existBlock);
    }

    public async ValueTask<IEnumerable<CottageBlockResultDto>> RetrieveAllByUserIdAsync(long userId)
    {
        var blocks = await _unitOfWork.CottageBlockRepository
            .SelectAll(block => block.UserId == userId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CottageBlockResultDto>>(source: blocks);
    }
}
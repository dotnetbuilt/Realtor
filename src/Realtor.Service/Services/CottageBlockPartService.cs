using AutoMapper;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.CottageBlockParts;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class CottageBlockPartService:ICottageBlockPartService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CottageBlockPartService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<CottageBlockPartResultDto> AddAsync(CottageBlockPartCreationDto dto)
    {
        var mappedBlockPart = _mapper.Map<CottageBlockPart>(source: dto);

        await _unitOfWork.CottageBlockPartRepository.CreateAsync(entity: mappedBlockPart);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CottageBlockPartResultDto>(source: mappedBlockPart);
    }

    public async ValueTask<CottageBlockPartResultDto> ModifyAsync(CottageBlockPartUpdateDto dto)
    {
        var existBlockPart =
            await _unitOfWork.CottageBlockPartRepository.SelectAsync(expression:blockPart => blockPart.Id == dto.Id);

        if (existBlockPart == null)
            throw new NotFoundException(message: "CottageBlockPart is not found");

        var mappedBlockPart = _mapper.Map(source: dto, destination: existBlockPart);
        
        _unitOfWork.CottageBlockPartRepository.Update(entity:mappedBlockPart);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CottageBlockPartResultDto>(source: mappedBlockPart);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existBlockPart =
            await _unitOfWork.CottageBlockPartRepository.SelectAsync(expression:blockPart => blockPart.Id == id);

        if (existBlockPart == null)
            throw new NotFoundException(message: "CottageBlockPart is not found");
        
        _unitOfWork.CottageBlockPartRepository.Delete(entity:existBlockPart);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<CottageBlockPartResultDto> RetrieveByIdAsync(long id)
    {
        var existBlockPart =
            await _unitOfWork.CottageBlockPartRepository.SelectAsync(expression:blockPart => blockPart.Id == id);

        if (existBlockPart == null)
            throw new NotFoundException(message: "CottageBlockPart is not found");

        return _mapper.Map<CottageBlockPartResultDto>(source: existBlockPart);
    }
}
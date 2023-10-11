using AutoMapper;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.ApartmentBlockParts;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class ApartmentBlockPartService:IApartmentBlockPartService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ApartmentBlockPartService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ApartmentBlockPartResultDto> AddAsync(ApartmentBlockPartCreationDto dto)
    {
        var mappedBlockPart = _mapper.Map<ApartmentBlockPart>(source: dto);

        await _unitOfWork.ApartmentBlockPartRepository.CreateAsync(entity: mappedBlockPart);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ApartmentBlockPartResultDto>(source: mappedBlockPart);
    }

    public async ValueTask<ApartmentBlockPartResultDto> ModifyAsync(ApartmentBlockPartUpdateDto dto)
    {
        var existBlockPart =
            await _unitOfWork.ApartmentBlockPartRepository.SelectAsync(blockPart => blockPart.Id == dto.Id);

        if (existBlockPart == null)
            throw new NotFoundException(message: "ApartmentBlockPart is not found");

        var mappedBlockPart = _mapper.Map(source: dto, destination: existBlockPart);
        
        _unitOfWork.ApartmentBlockPartRepository.Update(entity:mappedBlockPart);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ApartmentBlockPartResultDto>(source: mappedBlockPart);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existBlockPart =
            await _unitOfWork.ApartmentBlockPartRepository.SelectAsync(blockPart => blockPart.Id == id);
        
        if (existBlockPart == null)
            throw new NotFoundException(message: "ApartmentBlockPart is not found");
        
        _unitOfWork.ApartmentBlockPartRepository.Delete(entity:existBlockPart);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<ApartmentBlockPartResultDto> RetrieveByIdAsync(long id)
    {
        var existBlockPart =
            await _unitOfWork.ApartmentBlockPartRepository.SelectAsync(blockPart => blockPart.Id == id);
        
        if (existBlockPart == null)
            throw new NotFoundException(message: "ApartmentBlockPart is not found");

        return _mapper.Map<ApartmentBlockPartResultDto>(source: existBlockPart);
    }
}
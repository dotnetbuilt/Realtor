using AutoMapper;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Properties;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class PropertyService:IPropertyService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PropertyService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<PropertyResultDto> AddAsync(PropertyCreationDto dto)
    {
        var mappedProperty = _mapper.Map<Property>(source: dto);

        await _unitOfWork.PropertyRepository.CreateAsync(entity: mappedProperty);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<PropertyResultDto>(source: mappedProperty);
    }

    public async ValueTask<PropertyResultDto> ModifyAsync(PropertyUpdateDto dto)
    {
        var existProperty = 
            await _unitOfWork.PropertyRepository.SelectAsync(property => property.Id == dto.Id);

        if (existProperty == null)
            throw new NotFoundException(message: "Property is not found");

        var mappedProperty = _mapper.Map(source: dto, destination: existProperty);
        
        _unitOfWork.PropertyRepository.Update(entity:mappedProperty);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<PropertyResultDto>(source: mappedProperty);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existProperty = 
            await _unitOfWork.PropertyRepository.SelectAsync(property => property.Id == id);

        if (existProperty == null)
            throw new NotFoundException(message: "Property is not found");

        _unitOfWork.PropertyRepository.Delete(entity:existProperty);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<PropertyResultDto> RetrieveByIdAsync(long id)
    {
        var existProperty = 
            await _unitOfWork.PropertyRepository.SelectAsync(property => property.Id == id);

        if (existProperty == null)
            throw new NotFoundException(message: "Property is not found");

        return _mapper.Map<PropertyResultDto>(source: existProperty);
    }
}
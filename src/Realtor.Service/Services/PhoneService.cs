using AutoMapper;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Phones;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class PhoneService:IPhoneService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PhoneService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<PhoneResultDto> AddAsync(PhoneCreationDto dto)
    {
        var existPhone = await _unitOfWork.PhoneRepository
            .SelectAsync(phone => phone.Number.Equals(dto.Number));

        if (existPhone != null)
            throw new AlreadyExistsException(message: "Phone is already exists");

        var mappedPhone = _mapper.Map<Phone>(source: existPhone);

        await _unitOfWork.PhoneRepository.CreateAsync(entity: mappedPhone);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<PhoneResultDto>(source: mappedPhone);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existPhone = await _unitOfWork.PhoneRepository
            .SelectAsync(expression:phone => phone.Id == id);

        if (existPhone == null)
            throw new NotFoundException(message: "Phone is not found");

        _unitOfWork.PhoneRepository.Delete(entity:existPhone);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<PhoneResultDto> RetrieveByIdAsync(long id)
    {
        var existPhone = await _unitOfWork.PhoneRepository
            .SelectAsync(expression:phone => phone.Id == id);

        if (existPhone == null)
            throw new NotFoundException(message: "Phone is not found");

        return _mapper.Map<PhoneResultDto>(source: existPhone);
    }
}
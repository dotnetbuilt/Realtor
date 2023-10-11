using AutoMapper;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.UserProfiles;
using Realtor.Service.Exceptions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class UserProfileService:IUserProfileService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserProfileService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<UserProfileResultDto> AddAsync(UserProfileCreationDto dto)
    {
        var mappedUserProfile = _mapper.Map<UserProfile>(source: dto);

        await _unitOfWork.UserProfileRepository.CreateAsync(mappedUserProfile);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserProfileResultDto>(source: mappedUserProfile);
    }

    public async ValueTask<UserProfileResultDto> ModifyAsync(UserProfileUpdateDto dto)
    {
        var existProfile = await _unitOfWork.UserProfileRepository
            .SelectAsync(expression: profile => profile.Id == dto.Id, includes: new string[] { "User" });

        if (existProfile == null)
            throw new NotFoundException(message: "UserProfile is not found");

        var mappedProfile = _mapper.Map(source: dto, destination: existProfile);
        
        _unitOfWork.UserProfileRepository.Update(entity:mappedProfile);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserProfileResultDto>(source: mappedProfile);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existProfile = await _unitOfWork.UserProfileRepository
            .SelectAsync(expression: profile => profile.Id == id, includes: new string[] { "User" });

        if (existProfile == null)
            throw new NotFoundException(message: "UserProfile is not found");
        
        _unitOfWork.UserProfileRepository.Delete(entity:existProfile);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<UserProfileResultDto> RetrieveByIdAsync(long id)
    {
        var existProfile = await _unitOfWork.UserProfileRepository
            .SelectAsync(expression: profile => profile.Id == id, includes: new string[] { "User" });

        if (existProfile == null)
            throw new NotFoundException(message: "UserProfile is not found");

        return _mapper.Map<UserProfileResultDto>(source: existProfile);
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contracts;
using Realtor.Domain.Configurations;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Users;
using Realtor.Service.Exceptions;
using Realtor.Service.Extensions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class UserService:IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<UserResultDto> AddAsync(UserCreationDto dto)
    {
        var existUser = await _unitOfWork.UserRepository
            .SelectAsync(expression:user => user.PhoneNumber == dto.PhoneNumber);

        if (existUser != null)
            throw new AlreadyExistsException(message: "User is Already exist!");

        var mappedUser = _mapper.Map<User>(source:dto);
        mappedUser.Password.Hash();

        await _unitOfWork.UserRepository.CreateAsync(entity: mappedUser);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(source:mappedUser);
    }

    public async ValueTask<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        var existUser = await _unitOfWork.UserRepository
                            .SelectAsync(expression:user => user.Id == dto.Id)
                        ?? throw new NotFoundException(message: "User is not found!");

        _mapper.Map(source:dto, destination:existUser);

        _unitOfWork.UserRepository.Update(entity:existUser);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(source:existUser);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var existUser = await _unitOfWork.UserRepository
                            .SelectAsync(expression:user => user.Id == id)
                        ?? throw new NotFoundException(message: "User is not found!");

        _unitOfWork.UserRepository.Delete(entity:existUser);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<bool> EraseAsync(long id)
    {
        var existUser = await _unitOfWork.UserRepository
                            .SelectAsync(expression:user => user.Id == id)
                        ?? throw new NotFoundException(message: "User is not found!");
        
        _unitOfWork.UserRepository.Destroy(existUser);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<UserResultDto> RetrieveByIdAsync(long id)
    {
        var existUser = await _unitOfWork.UserRepository
                            .SelectAsync(expression:user => user.Id == id)
                        ?? throw new NotFoundException(message: "User is not found!");

        return _mapper.Map<UserResultDto>(source: existUser);
    }

    public async ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await _unitOfWork.UserRepository
            .SelectAll().ToPaginate(@params).ToListAsync();

        return _mapper.Map<IEnumerable<UserResultDto>>(source: users);
    }

    public async ValueTask<long> RetrieveNumberOfActiveUsers()
        => await _unitOfWork.UserRepository.SelectAll(expression: user => user.IsDeleted == false).LongCountAsync();

    public async ValueTask<bool> ChangePasswordAsync(long userId, string currentPassword, string newPassword)
    {
        var user = await _unitOfWork.UserRepository
            .SelectAsync(expression: user => user.Id == userId) 
                   ?? throw new NotFoundException(message: "User is not found");

        if (!currentPassword.Verify(user.Password))
            throw new CustomException(statuscode:403,message: "Password is invalid");

        user.Password = newPassword.Hash();
        await _unitOfWork.SaveAsync();

        return true;
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Realtor.Domain.Configurations;
using Realtor.Service.DTOs.Users;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class UsersController:BaseController
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async ValueTask<IActionResult> CreateAsync(UserCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });
    
    
    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(UserUpdateDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ModifyAsync(dto)
        });
    
    
    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long userId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(userId)
        });
    
    
    [HttpDelete("destroy")]
    public async ValueTask<IActionResult> DestroyAsync(long userId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.EraseAsync(userId)
        });
    
    
    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long userId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(userId)
        });
    
    
    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveAllAsync(@params)
        });
    
    [HttpPatch("change-password")]
    public async ValueTask<IActionResult> ModifyPasswordAsync(long userId,string currentPassword,string newPassword)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ChangePasswordAsync(userId,currentPassword,newPassword)
        });

    [HttpGet("get-number-of-active-users")]
    public async ValueTask<IActionResult> GetNumberOfActiveUsers()
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveNumberOfActiveUsers()
        });
}
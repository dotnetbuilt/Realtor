using Microsoft.AspNetCore.Mvc;
using Realtor.Service.DTOs.Addresses;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class AddressesController:BaseController
{
    private readonly IAddressService _service;

    public AddressesController(IAddressService service)
    {
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(AddressCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });
    
    
    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(AddressUpdateDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ModifyAsync(dto)
        });
    
    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long addressId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(addressId)
        });

    [HttpDelete("destroy")]
    public async ValueTask<IActionResult> DestroyAsync(long addressId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.EraseAsync(addressId)
        });
    
    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long addressId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(addressId)
        });
    
    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveAllAsync()
        });
}
using Microsoft.AspNetCore.Mvc;
using Realtor.Service.DTOs.ApartmentBlocks;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class ApartmentBlocksController : BaseController
{
    private readonly IApartmentBlockService _service;

    public ApartmentBlocksController(IApartmentBlockService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(ApartmentBlockCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "ok",
            Data = await _service.AddAsync(dto)
        });

    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(ApartmentBlockUpdateDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _service.ModifyAsync(dto)
        });

    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _service.RemoveAsync(id)
        });

    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _service.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all-by-user-id")]
    public async ValueTask<IActionResult> GetAllByUserIdAsync(long userId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _service.RetrieveAllByUserIdAsync(userId)
        });
}
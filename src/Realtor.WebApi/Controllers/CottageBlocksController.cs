using Microsoft.AspNetCore.Mvc;
using Realtor.Service.DTOs.CottageBlocks;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class CottageBlocksController:BaseController
{
    private readonly ICottageBlockService _service;

    public CottageBlocksController(ICottageBlockService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(CottageBlockCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _service.AddAsync(dto)
        });

    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(CottageBlockUpdateDto dto)
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
}
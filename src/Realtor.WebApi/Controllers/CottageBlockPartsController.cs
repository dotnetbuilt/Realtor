using Microsoft.AspNetCore.Mvc;
using Realtor.Service.DTOs.CottageBlockParts;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class CottageBlockPartsController:BaseController
{
    private readonly ICottageBlockPartService _service;

    public CottageBlockPartsController(ICottageBlockPartService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(CottageBlockPartCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _service.AddAsync(dto)
        });

    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(CottageBlockPartUpdateDto dto)
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
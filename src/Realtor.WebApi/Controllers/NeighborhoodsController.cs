using Microsoft.AspNetCore.Mvc;
using Realtor.Service.DTOs.Neighborhoods;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class NeighborhoodsController:BaseController
{
    private readonly INeighborhoodService _service;

    public NeighborhoodsController(INeighborhoodService service)
    {
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(NeighborhoodCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });
    
    
    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(NeighborhoodUpdateDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ModifyAsync(dto)
        });
    
    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long neighborhoodId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(neighborhoodId)
        });

    [HttpDelete("destroy")]
    public async ValueTask<IActionResult> DestroyAsync(long neighborhoodId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.EraseAsync(neighborhoodId)
        });
    
    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long neighborhoodId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(neighborhoodId)
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
using Microsoft.AspNetCore.Mvc;
using Realtor.Service.DTOs.Regions;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class RegionsController:BaseController
{
    private readonly IRegionService _service;

    public RegionsController(IRegionService service)
    {
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(RegionCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });
    
    
    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(RegionUpdateDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ModifyAsync(dto)
        });
    
    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long regionId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(regionId)
        });

    [HttpDelete("destroy")]
    public async ValueTask<IActionResult> DestroyAsync(long regionId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.EraseAsync(regionId)
        });
    
    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long regionId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(regionId)
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
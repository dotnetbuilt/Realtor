using Microsoft.AspNetCore.Mvc;
using Realtor.Service.DTOs.Properties;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class PropertiesController : BaseController
{
    private readonly IPropertyService _service;

    public PropertiesController(IPropertyService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(PropertyCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _service.AddAsync(dto)
        });

    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(PropertyUpdateDto dto)
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
using Microsoft.AspNetCore.Mvc;
using Realtor.Service.DTOs.Phones;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class PhonesController:BaseController
{
    private readonly IPhoneService _service;

    public PhonesController(IPhoneService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(PhoneCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _service.AddAsync(dto)
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
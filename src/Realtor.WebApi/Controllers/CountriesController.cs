using Microsoft.AspNetCore.Mvc;
using Realtor.Service.DTOs.Countries;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class CountriesController:BaseController
{
    private readonly ICountryService _service;

    public CountriesController(ICountryService service)
    {
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(CountryCreationDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });
    
    
    [HttpPut("update")]
    public async ValueTask<IActionResult> UpdateAsync(CountryUpdateDto dto)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.ModifyAsync(dto)
        });
    
    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long countryId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(countryId)
        });

    [HttpDelete("destroy")]
    public async ValueTask<IActionResult> DestroyAsync(long countryId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.EraseAsync(countryId)
        });
    
    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long countryId)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(countryId)
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
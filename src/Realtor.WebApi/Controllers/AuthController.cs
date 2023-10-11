using Microsoft.AspNetCore.Mvc;
using Realtor.Service.Interfaces;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Controllers;

public class AuthController:BaseController
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async ValueTask<IActionResult> GenerateTokenAsync(string phone, string password)
        => Ok(new Responce()
        {
            StatusCode = 200,
            Message = "Ok",
            Data = await _service.GenerateAndCacheTokenAsyncByPhone(phone, password)
        });
}
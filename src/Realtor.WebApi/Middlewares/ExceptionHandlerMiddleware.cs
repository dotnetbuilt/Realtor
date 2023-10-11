using Realtor.Service.Exceptions;
using Realtor.WebApi.Models;

namespace Realtor.WebApi.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _request;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _request = request;
        _logger = logger;
    }

    public async Task Invoke(HttpContext _context)
    {
        try
        {
            _request.Invoke(_context);
        }
        catch (NotFoundException exception)
        {
            _context.Response.StatusCode = exception.StatusCode;

            await _context.Response.WriteAsJsonAsync(new Responce()
            {
                StatusCode = _context.Response.StatusCode,
                Message = exception.Message
            });
        }
        catch (AlreadyExistsException exception)
        {
            _context.Response.StatusCode = exception.StatusCode;

            await _context.Response.WriteAsJsonAsync(new Responce()
            {
                StatusCode = _context.Response.StatusCode,
                Message = exception.Message
            });
        }
        catch (CustomException exception)
        {
            _context.Response.StatusCode = exception.StatusCode;

            await _context.Response.WriteAsJsonAsync(new Responce()
            {
                StatusCode = _context.Response.StatusCode,
                Message = exception.Message
            });
        }
        catch (Exception exception)
        {
            _context.Response.StatusCode = 500;
            _logger.LogError(message:exception.ToString());

            await _context.Response.WriteAsJsonAsync(new Responce()
            {
                StatusCode = _context.Response.StatusCode,
                Message = exception.Message
            });
        }
    }
}
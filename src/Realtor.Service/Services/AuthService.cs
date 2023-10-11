using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Realtor.Data.Contracts;
using Realtor.Service.Exceptions;
using Realtor.Service.Extensions;
using Realtor.Service.Interfaces;

namespace Realtor.Service.Services;

public class AuthService:IAuthService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IMemoryCache memoryCache, IConfiguration configuration, IUnitOfWork unitOfWork)
    {
        _memoryCache = memoryCache;
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    public string GetUserIdFromToken(string token)
    {
        var tokenhandler = new JwtSecurityTokenHandler();

        if (tokenhandler.CanReadToken(token))
        {
            var jwtToken = tokenhandler.ReadJwtToken(token);
            var idClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "Id");

            if (idClaim != null)
            {
                return idClaim.Value;
            }
        }

        return null;
    }

    public async Task<string> GenerateAndCacheTokenAsyncByEmail(string email, string password)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(expression: u => u.Email == email)
                   ?? throw new NotFoundException(message: "UserNotFound");

        bool isPasswordVerified = password.Verify(user.Password);
        if (!isPasswordVerified)
            throw new CustomException(statuscode: 400, message: "Password is invalid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        string result = tokenHandler.WriteToken(token);

        _memoryCache.Set(user.Id.ToString(), result, TimeSpan.FromDays(1));

        return result;
    }
}
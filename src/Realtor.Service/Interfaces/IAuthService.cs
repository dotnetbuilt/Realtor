namespace Realtor.Service.Interfaces;

public interface IAuthService
{
    public string GetUserIdFromToken(string token);
    Task<string> GenerateAndCacheTokenAsyncByEmail(string email, string password);
}


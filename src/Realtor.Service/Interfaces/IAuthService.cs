namespace Realtor.Service.Interfaces;

public interface IAuthService
{
    Task<string> GenerateAndCacheTokenAsyncByEmail(string email, string password);
}


namespace Realtor.Service.Interfaces;

public interface IAuthService
{
    Task<string> GenerateAndCacheTokenAsyncByPhone(string phone, string password);
}


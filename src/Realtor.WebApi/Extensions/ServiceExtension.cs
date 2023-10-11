using Realtor.Data.Contracts;
using Realtor.Data.Repositories;
using Realtor.Service.Interfaces;
using Realtor.Service.Services;

namespace Realtor.WebApi.Extensions;

public static class ServiceExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserProfileService, UserProfileService>();
        services.AddScoped<IAddressService, AddressService>();
    }
}
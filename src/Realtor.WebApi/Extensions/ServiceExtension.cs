using System.Runtime.Intrinsics.X86;
using Realtor.Data.Contracts;
using Realtor.Data.Repositories;
using Realtor.Domain.Entities;
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
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IRegionService, RegionService>();
        services.AddScoped<IDistrictService, DistrictService>();
        services.AddScoped<INeighborhoodService, NeighborhoodService>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<ILinkService, LinkService>();
        services.AddScoped<IPhoneService, PhoneService>();
        services.AddScoped<IApartmentService, ApartmentService>();
        services.AddScoped<IApartmentBlockService, ApartmentBlockService>();
        services.AddScoped<IApartmentBlockPartService, ApartmentBlockPartService>();
        services.AddScoped<ICottageService, CottageService>();
        services.AddScoped<ICottageBlockService, CottageBlockService>();
        services.AddScoped<ICottageBlockPartService, CottageBlockPartService>();
    }
}
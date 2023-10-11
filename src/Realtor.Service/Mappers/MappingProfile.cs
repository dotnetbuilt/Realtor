using AutoMapper;
using Realtor.Domain.Entities;
using Realtor.Service.DTOs.Addresses;
using Realtor.Service.DTOs.ApartmentBlockParts;
using Realtor.Service.DTOs.ApartmentBlocks;
using Realtor.Service.DTOs.Apartments;
using Realtor.Service.DTOs.CottageBlockParts;
using Realtor.Service.DTOs.CottageBlocks;
using Realtor.Service.DTOs.Cottages;
using Realtor.Service.DTOs.Countries;
using Realtor.Service.DTOs.Districts;
using Realtor.Service.DTOs.Links;
using Realtor.Service.DTOs.Neighborhoods;
using Realtor.Service.DTOs.Phones;
using Realtor.Service.DTOs.Properties;
using Realtor.Service.DTOs.Regions;
using Realtor.Service.DTOs.UserProfiles;
using Realtor.Service.DTOs.Users;

namespace Realtor.Service.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();
        
        //UserProfile
        CreateMap<UserProfile, UserProfileCreationDto>().ReverseMap();
        CreateMap<UserProfile, UserProfileUpdateDto>().ReverseMap();
        CreateMap<UserProfile, UserProfileResultDto>().ReverseMap();
        
        //Address
            CreateMap<Address, AddressUpdateDto>().ReverseMap();
            CreateMap<Address, AddressCreationDto>().ReverseMap();
            CreateMap<Address, AddressResultDto>().ReverseMap();
            
            //Country
            CreateMap<Country, CountryResultDto>().ReverseMap();
            CreateMap<Country, CountryCreationDto>().ReverseMap();
            CreateMap<Country, CountryUpdateDto>().ReverseMap();
            
            //Region
            CreateMap<Region, RegionUpdateDto>().ReverseMap();
            CreateMap<Region, RegionCreationDto>().ReverseMap();
            CreateMap<Region, RegionResultDto>().ReverseMap();
            
            //District
            CreateMap<District, DistrictUpdateDto>().ReverseMap();
            CreateMap<District, DistrictCreationDto>().ReverseMap();
            CreateMap<District, DistrictResultDto>().ReverseMap();
            
            //Neighborhood
            CreateMap<Neighborhood, NeighborhoodUpdateDto>().ReverseMap();
            CreateMap<Neighborhood, NeighborhoodCreationDto>().ReverseMap();
            CreateMap<Neighborhood, NeighborhoodResultDto>().ReverseMap();
            
            //Link
            CreateMap<Link, LinkCreationDto>().ReverseMap();
            CreateMap<Link, LinkUpdateDto>().ReverseMap();
            CreateMap<Link, LinkResultDto>().ReverseMap();
            
            //Phone
            CreateMap<Phone, PhoneCreationDto>().ReverseMap();
            CreateMap<Phone, PhoneUpdateDto>().ReverseMap();
            CreateMap<Phone, PhoneResultDto>().ReverseMap();
        
            //Apartment
            CreateMap<Apartment, ApartmentCreationDto>().ReverseMap();
            CreateMap<Apartment, ApartmentUpdateDto>().ReverseMap();
            CreateMap<Apartment, ApartmentResultDto>().ReverseMap();
            
            //ApartmentBlock
            CreateMap<ApartmentBlock, ApartmentBlockCreationDto>().ReverseMap();
            CreateMap<ApartmentBlock, ApartmentBlockUpdateDto>().ReverseMap();
            CreateMap<ApartmentBlock, ApartmentBlockResultDto>().ReverseMap();
            
            //ApartmentBlockPart
            CreateMap<ApartmentBlockPart, ApartmentBlockPartCreationDto>().ReverseMap();
            CreateMap<ApartmentBlockPart, ApartmentBlockPartUpdateDto>().ReverseMap();
            CreateMap<ApartmentBlockPart, ApartmentBlockPartResultDto>().ReverseMap();
            
            //Cottage
            CreateMap<Cottage, CottageCreationDto>().ReverseMap();
            CreateMap<Cottage, CottageUpdateDto>().ReverseMap();
            CreateMap<Cottage, CottageResultDto>().ReverseMap();
            
            //CottageBlock
            CreateMap<CottageBlock, CottageBlockCreationDto>().ReverseMap();
            CreateMap<CottageBlock, CottageBlockUpdateDto>().ReverseMap();
            CreateMap<CottageBlock, CottageBlockResultDto>().ReverseMap();

            //CottageBlockPart
            CreateMap<CottageBlockPart, CottageBlockPartCreationDto>().ReverseMap();
            CreateMap<CottageBlockPart, CottageBlockPartUpdateDto>().ReverseMap();
            CreateMap<CottageBlockPart, CottageBlockPartResultDto>().ReverseMap();
            
            //Property
            CreateMap<Property, PropertyCreationDto>().ReverseMap();
            CreateMap<Property, PropertyUpdateDto>().ReverseMap();
            CreateMap<Property, PropertyResultDto>().ReverseMap();
    }
}
using Realtor.Domain.Entities;

namespace Realtor.Data.Contracts;

public interface IUnitOfWork:IDisposable
{
    IRepository<User> UserRepository { get; }
    IRepository<Attachment> AttachmentRepository { get; }
    IRepository<Address> AddressRepository { get; }
    IRepository<Country> CountryRepository { get; }
    IRepository<Region> RegionRepository { get; }
    IRepository<District> DistrictRepository { get; }
    IRepository<Neighborhood> NeighborhoodRepository { get; }
    IRepository<Apartment> ApartmentRepository { get; }
    IRepository<ApartmentBlock> ApartmentBlockRepository { get; }
    IRepository<ApartmentBlockPart> ApartmentBlockPartRepository { get; }
    IRepository<Cottage> CottageRepository { get; }
    IRepository<CottageBlock> CottageBlockRepository { get; }
    IRepository<CottageBlockPart> CottageBlockPartRepository { get; }
    IRepository<Property> PropertyRepository { get; }
    IRepository<Link> LinkRepository { get; }
    IRepository<Phone> PhoneRepository { get; }
    ValueTask SaveAsync();
}
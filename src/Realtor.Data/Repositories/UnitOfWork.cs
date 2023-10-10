using Realtor.Data.Contexts;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;

namespace Realtor.Data.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly RealtorDbContext _context;

    public UnitOfWork(RealtorDbContext context)
    {
        _context = context;
        UserRepository = new Repository<User>(_context);
        UserProfileRepository = new Repository<UserProfile>(_context);
        AttachmentRepository = new Repository<Attachment>(_context);
        AddressRepository = new Repository<Address>(_context);
        CountryRepository = new Repository<Country>(_context);
        RegionRepository = new Repository<Region>(_context);
        DistrictRepository = new Repository<District>(_context);
        NeighborhoodRepository = new Repository<Neighborhood>(_context);
        ApartmentRepository = new Repository<Apartment>(_context);
        ApartmentBlockRepository = new Repository<ApartmentBlock>(_context);
        ApartmentBlockPartRepository = new Repository<ApartmentBlockPart>(_context);
        CottageRepository = new Repository<Cottage>(_context);
        CottageBlockRepository = new Repository<CottageBlock>(_context);
        CottageBlockPartRepository = new Repository<CottageBlockPart>(_context);
        PropertyRepository = new Repository<Property>(_context);
        LinkRepository = new Repository<Link>(_context);
        PhoneRepository = new Repository<Phone>(_context);
    }

    public IRepository<User> UserRepository { get; }
    public IRepository<UserProfile> UserProfileRepository { get; }
    public IRepository<Attachment> AttachmentRepository { get; }
    public IRepository<Address> AddressRepository { get; }
    public IRepository<Country> CountryRepository { get; }
    public IRepository<Region> RegionRepository { get; }
    public IRepository<District> DistrictRepository { get; }
    public IRepository<Apartment> ApartmentRepository { get; }
    public IRepository<ApartmentBlock> ApartmentBlockRepository { get; }
    public IRepository<ApartmentBlockPart> ApartmentBlockPartRepository { get; }
    public IRepository<Cottage> CottageRepository { get; }
    public IRepository<CottageBlock> CottageBlockRepository { get; }
    public IRepository<CottageBlockPart> CottageBlockPartRepository { get; }
    public IRepository<Property> PropertyRepository { get; }
    public IRepository<Link> LinkRepository { get; }
    public IRepository<Phone> PhoneRepository { get; }
    public IRepository<Neighborhood> NeighborhoodRepository { get; }
    public async ValueTask SaveAsync() => await _context.SaveChangesAsync();

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }
}
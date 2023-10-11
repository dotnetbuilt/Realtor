using Realtor.Data.Contexts;
using Realtor.Data.Contracts;
using Realtor.Domain.Entities;

namespace Realtor.Data.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly RealtorDbContext _context;

    public UnitOfWork(RealtorDbContext context, IRepository<User> userRepository,
        IRepository<Attachment> attachmentRepository, IRepository<Address> addressRepository, 
        IRepository<Country> countryRepository, IRepository<Region> regionRepository, 
        IRepository<District> districtRepository, IRepository<Apartment> apartmentRepository, 
        IRepository<ApartmentBlock> apartmentBlockRepository, IRepository<ApartmentBlockPart> apartmentBlockPartRepository,
        IRepository<Cottage> cottageRepository, IRepository<CottageBlock> cottageBlockRepository,
        IRepository<CottageBlockPart> cottageBlockPartRepository, IRepository<Property> propertyRepository, 
        IRepository<Link> linkRepository, IRepository<Phone> phoneRepository, 
        IRepository<Neighborhood> neighborhoodRepository)
    {
        _context = context;
        UserRepository = userRepository;
        AttachmentRepository = attachmentRepository;
        AddressRepository = addressRepository;
        CountryRepository = countryRepository;
        RegionRepository = regionRepository;
        DistrictRepository = districtRepository;
        ApartmentRepository = apartmentRepository;
        ApartmentBlockRepository = apartmentBlockRepository;
        ApartmentBlockPartRepository = apartmentBlockPartRepository;
        CottageRepository = cottageRepository;
        CottageBlockRepository = cottageBlockRepository;
        CottageBlockPartRepository = cottageBlockPartRepository;
        PropertyRepository = propertyRepository;
        LinkRepository = linkRepository;
        PhoneRepository = phoneRepository;
        NeighborhoodRepository = neighborhoodRepository;
    }

    public IRepository<User> UserRepository { get; }
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

    public async ValueTask SaveAsync()
    {
        await _context.SaveChangesAsync();  
    } 

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }
}
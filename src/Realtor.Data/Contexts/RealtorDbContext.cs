using Microsoft.EntityFrameworkCore;
using Realtor.Domain.Entities;

namespace Realtor.Data.Contexts;

public class RealtorDbContext:DbContext
{
    public RealtorDbContext(DbContextOptions<RealtorDbContext> options):base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Neighborhood> Neighborhoods { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<ApartmentBlock> ApartmentBlocks { get; set; }
    public DbSet<ApartmentBlockPart> ApartmentBlockParts { get; set; }
    public DbSet<Cottage> Cottages { get; set; }
    public DbSet<CottageBlock> CottageBlocks { get; set; }
    public DbSet<CottageBlockPart> CottageBlockParts { get; set; }
    public DbSet<Link> Links { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Property> Properties { get; set; }
}
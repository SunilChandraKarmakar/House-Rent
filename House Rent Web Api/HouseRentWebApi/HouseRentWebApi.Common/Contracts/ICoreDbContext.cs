using HouseRentWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.Common.Contracts
{
    public interface ICoreDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<FurnishingType> FurnishingTypes { get; set; }
        DbSet<Photo> Photos { get; set; }
        DbSet<Property> Properties { get; set; }
        DbSet<PropertyType> PropertyTypes { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
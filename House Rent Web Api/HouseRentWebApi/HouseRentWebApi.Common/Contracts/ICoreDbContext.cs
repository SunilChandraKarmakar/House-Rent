using HouseRentWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.Common.Contracts
{
    public interface ICoreDbContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<City> Cities { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
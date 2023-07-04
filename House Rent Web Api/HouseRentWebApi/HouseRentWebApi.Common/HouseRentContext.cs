using HouseRentWebApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.Common
{
    public class HouseRentContext : IdentityDbContext<User, IdentityRole, string>
    {
        public HouseRentContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
using HouseRentWebApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.Common
{
    public class HouseRentContext : IdentityDbContext<User, IdentityRole, string>
    {
        public HouseRentContext(DbContextOptions<HouseRentContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = @"Data Source = DESKTOP-O1NBMET; 
                                    Initial Catalog = HouseRentDb; 
                                    Integrated Security = True;
                                    TrustServerCertificate = True";

                options.UseSqlServer(connectionString);
                //options.EnableSensitiveDataLogging();
            }
        }
    }
}
using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentWebApi.Common
{
    public class HouseRentContext : IdentityDbContext<User, IdentityRole, string>, ICoreDbContext
    {
        public HouseRentContext(DbContextOptions<HouseRentContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {            
            return base.SaveChangesAsync(cancellationToken);
        }

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
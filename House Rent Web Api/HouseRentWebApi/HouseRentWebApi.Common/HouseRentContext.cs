using HouseRentWebApi.Common.Contracts;
using HouseRentWebApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HouseRentWebApi.Common
{
    public class HouseRentContext : IdentityDbContext<User, IdentityRole, string>, ICoreDbContext
    {
        public HouseRentContext(DbContextOptions<HouseRentContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<FurnishingType> FurnishingTypes { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {            
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
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
                // options.EnableSensitiveDataLogging();
            }
        }
    }
}
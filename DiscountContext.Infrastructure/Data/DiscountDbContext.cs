using DiscountContext.Domain.Entities;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DiscountContext.Infrastructure.Data
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
            : base(options)
        {
        }

        public DbSet<Republic> Republics { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new RepublicConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());

            modelBuilder.Entity<Company>()
            .Ignore(c => c.Address.Notifications);
            modelBuilder.Entity<Republic>()
            .Ignore(r => r.Address.Notifications);



            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountDbContext).Assembly);
        }
    }
}

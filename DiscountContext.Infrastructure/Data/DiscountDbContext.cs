using DiscountContext.Domain.Entities;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Infrastructure.Data.Configurations;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DiscountContext.Infrastructure.Data
{
    public class DiscountDbContext : DbContext
    {
        public DbSet<Republic> Republics { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)=>
            options.UseSqlServer("Server=localhost;Database=RepublicaApp;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountDbContext).Assembly);
        }
    }
}

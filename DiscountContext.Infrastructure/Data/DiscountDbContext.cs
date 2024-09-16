using DiscountContext.Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace DiscountContext.Infrastructure.Data
{
    public class DiscountDbContext : DbContext
    {

        public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
        : base(options)
        {
        }

        public DbSet<Republic> Republics { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountDbContext).Assembly);
        }
    }
}

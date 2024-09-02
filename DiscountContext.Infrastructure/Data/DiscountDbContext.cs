using DiscountContext.Domain.Entities;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscountContext.Infrastructure.Data;

public class DiscountDbContext : IdentityDbContext <User,IdentityRole<long>, long>
{
    public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
    : base(options)
    {
    }

    public DbSet<Republic> Republics { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<User>  Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<Notification>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountDbContext).Assembly);
    }
}

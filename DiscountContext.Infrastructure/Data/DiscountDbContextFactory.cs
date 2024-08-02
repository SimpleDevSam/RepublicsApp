using DiscountContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class DiscountDbContextFactory : IDesignTimeDbContextFactory<DiscountDbContext>
{
    public DiscountDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DiscountDbContext>();

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);

        return new DiscountDbContext(optionsBuilder.Options);
    }
}
using DiscountContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace YourProject.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DiscountDbContext>
    {
        public DiscountDbContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DiscountDbContext>();
            //var connectionString = configuration.GetConnectionString("Server=(localdb)\\mssqllocaldb;Database=RepublicaApp;Trusted_Connection=True;MultipleActiveResultSets=true");

            optionsBuilder.UseSqlServer("Server=(localdb)\\\\mssqllocaldb;Database=RepublicaApp;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new DiscountDbContext(optionsBuilder.Options);
        }
    }
}

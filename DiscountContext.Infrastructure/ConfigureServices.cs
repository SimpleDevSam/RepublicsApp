using DiscountContext.Domain.Repositories;
using DiscountContext.Infrastructure.Data;
using DiscountContext.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DiscountContext.Infrastructure
{
    public static class ConfigureServices
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<DiscountDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IRepublicRepository, RepublicRepository>(); 

            
        }

    }
}

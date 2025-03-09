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
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DiscountDbContext>(options =>
                options.UseSqlServer(connectionString));
                
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IRepublicRepository, RepublicRepository>();  
        }

    }
}

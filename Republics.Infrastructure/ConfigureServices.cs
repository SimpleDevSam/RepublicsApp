using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Republics.Domain.Repositories;
using Republics.Infrastructure.Data;
using Republics.Infrastructure.Repositories;


namespace Republics.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DiscountDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IRepublicRepository, RepublicRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        return services;
    }

}

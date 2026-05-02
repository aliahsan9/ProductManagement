using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Interfaces.UnitOfWork;
using ProductManagement.Infrastructure.Persistence;
using ProductManagement.Infrastructure.Repositories;

namespace ProductManagement.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>

                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddRepositories();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        });

        return services;
    }
}

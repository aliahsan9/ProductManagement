using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.Interfaces.Services;

namespace ProductManagement.Application.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection sevices)
        {
            // Servies
            services.AddScoped<IProductService, ProductService>();

            // AutoMapper
            services.AddAutoMapper(typeof(ServiceRegistration).Assembly);

            return services;
        }
    }
}

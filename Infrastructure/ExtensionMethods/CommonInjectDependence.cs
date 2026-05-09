using Cadastro.Domain.Interfaces;
using Cadastro.Infrastructure.Data.Repositories;
using Cadastro.Interfaces;
using Cadastro.Services;

namespace Cadastro.Infrastructure.ExtensionMethods
{
    public static class CommonInjectDependence
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddTransient<IClientViewModelService, ClientViewModelService>();
            services.AddTransient<IProductViewModelService, ProductViewModelService>();


            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();


            return services;
        }
    }
}

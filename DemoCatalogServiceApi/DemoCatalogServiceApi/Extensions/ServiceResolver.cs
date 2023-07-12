using DemoCatalogServiceApi.DataAccess.Nortwind.Content;
using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;
using DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces;
using DemoCatalogServiceApi.DataAccess.Nortwind.Model;
using DemoCatalogServiceApi.DataAccess.Nortwind.Repository;
using DemoCatalogServiceApi.DataAccess.Nortwind.Service;
using Microsoft.EntityFrameworkCore;

namespace DemoCatalogServiceApi.Extensions
{
    public static class ServiceResolver
    {
        public static void RegisterNortwindServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, NortwindContext>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IFilterService<Product, ProductCriteriaInput>, ProductFilterService>();

            services.AddAutoMapper(typeof(Startup));
        }
    }
}

using Eternity.DataProvider;
using Eternity.DataProvider.Interfaces;
using Eternity.DataProvider.Models;
using Eternity.DataProvider.Repository;
using Eternity.Logic.Interfaces;
using Eternity.Logic.Services;

namespace Eternity.Website
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<About>, AboutRepository>();
            services.AddScoped<IBaseRepository<Key>, KeyRepository>();
            services.AddScoped<IBaseRepository<Price>, PriceRepository>();
            services.AddScoped<IBaseRepository<Service>, ServiceRepository>();
            services.AddScoped<IBaseRepository<Work>, WorkRepository>();
        }
        public static void InitializeServices(this IServiceCollection services) 
        {
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IKeyService, KeyService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

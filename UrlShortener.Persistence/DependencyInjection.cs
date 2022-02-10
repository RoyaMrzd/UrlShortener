
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Persistence.Interfaces;
using UrlShortener.Persistence.Repositories;

namespace UrlShortener.Persistence
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceDI(this IServiceCollection services, IConfiguration configuration)
        {

            var databaseConnectionString = configuration.GetConnectionString("UrlShortenerApiDatabase");

            services.AddDbContext<UrlShortenerDbContext>(options =>
            options.UseSqlServer(databaseConnectionString));
            services.AddScoped<IUrlShortenerDbContext>(provider => provider.GetService<UrlShortenerDbContext>());
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUrlShortenerRepository, UrlShortenerRepository>();


            return services;

        }
    }


}

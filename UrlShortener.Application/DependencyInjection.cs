using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace UrlShortener.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddScoped<IRequestResponseHandler<CreateUrlShortenerCommand, string>, CreateUrlShortenerCommandHandler>();

            return services;
        }
    }
}

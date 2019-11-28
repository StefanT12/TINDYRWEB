using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebshopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LocalAppDb")));

            services.AddScoped<IDbContext>(provider => provider.GetService<WebshopDbContext>());

            return services;
        }
    }
}

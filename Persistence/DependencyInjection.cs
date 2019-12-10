using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TindyrDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LocalAppDb")
                    //,
                    //sqlServerOptions =>
                    //{
                    //    sqlServerOptions.MigrationsAssembly(typeof(TindyrDbContext).GetTypeInfo().Assembly.FullName);
                    //}
                    )
                );

            services.AddScoped<ITindyrDbContext>(provider => provider.GetService<TindyrDbContext>());

            return services;
        }
    }
}

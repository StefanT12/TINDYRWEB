using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using AppChat;
using System.Reflection;

namespace AppChat
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppChat(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("LocalAppDb")
                    //,
                    //sqlServerOptions =>
                    //{
                    //    sqlServerOptions.MigrationsAssembly(typeof(ChatDbContext).GetTypeInfo().Assembly.FullName);
                    //})
                ));

            //services.AddScoped(provider => provider.GetService<ChatDbContext>());

            services.AddScoped<IAppChat, AppChat>();

            return services;
        }
    }
}

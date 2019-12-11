using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Chat;
using System.Reflection;

namespace Chat
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

            services.AddScoped<IChatDbContext>(provider => provider.GetService<ChatDbContext>()); 

            services.AddScoped<Application.Common.Interfaces.IAppChat, Chat.AppChat>();

            return services;
        }
    }
}

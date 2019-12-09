using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using AppChat;

namespace AppChat
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppChat(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LocalAppDb")));

            services.AddScoped(provider => provider.GetService<ChatDbContext>());

            services.AddScoped<IAppChat, AppChat>();

            return services;
        }
    }
}

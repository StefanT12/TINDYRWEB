using Microsoft.Extensions.DependencyInjection;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ApplicationUser
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationUser(this IServiceCollection services)
        {
            services.AddScoped<IUserAuthentication, UserAuthentication>();
            services.AddScoped<IAppUser, AppUser>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            return services;
        }
    }
}

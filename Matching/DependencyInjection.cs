using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Matching
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLiveMatch(this IServiceCollection services)
        {
            services.AddScoped<ILiveMatch, LiveMatch>();

            return services;
        }
    }
}

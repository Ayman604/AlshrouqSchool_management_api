using AlshrouqSchool.Application;
using AlshrouqSchool.Infrastructure;

namespace AlshrouqSchool.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                    .AddInfrastructureDI();
            return services;
        }
    }
}

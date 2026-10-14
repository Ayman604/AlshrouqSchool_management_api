using System.Reflection;

namespace AlshrouqSchool.Api.Extensions
{
    public static class WebApplicationRegister
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}

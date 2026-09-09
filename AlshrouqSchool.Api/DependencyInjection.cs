using AlshrouqSchool.Application;
using AlshrouqSchool.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace AlshrouqSchool.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDI().AddInfrastructureDI(configuration);
        services.AddAuthentication(IdentityConstants.BearerScheme)
            .AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorization();
        return services;
    }
}

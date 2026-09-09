using AlshrouqSchool.Application.Interfaces;
using AlshrouqSchool.Core.Entities.Identity;
using AlshrouqSchool.Infrastructure.Data;
using AlshrouqSchool.Infrastructure.LiveKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlshrouqSchool.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");
        services.AddDbContext<AlshrouqDbContext>(options => options.UseSqlServer(connectionString));
        services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AlshrouqDbContext>();
        services.Configure<LiveKitOptions>(options =>
        {
            options.Url = configuration["LiveKit:Url"] ?? string.Empty;
            options.ApiKey = configuration["LiveKit:ApiKey"] ?? string.Empty;
            options.ApiSecret = configuration["LiveKit:ApiSecret"] ?? string.Empty;
            options.TokenLifetimeMinutes = int.TryParse(configuration["LiveKit:TokenLifetimeMinutes"], out var minutes) ? minutes : 60;
        });
        services.AddScoped<ILiveKitService, LiveKitService>();
        return services;
    }
}

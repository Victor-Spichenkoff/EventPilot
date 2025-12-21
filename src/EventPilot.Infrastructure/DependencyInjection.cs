using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Infrastructure.Context;
using EventPilot.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace EventPilot.Infrastructure;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
            IConfiguration config
        )
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(config.GetConnectionString("Default")));
        
        //Repositories Here
        services.AddScoped<IEventRepository, EventRepository>();
        
        
        return services;
    }
}
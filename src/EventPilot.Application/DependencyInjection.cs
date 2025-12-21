using EventPilot.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventPilot.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        //Services
        services.AddScoped<TestService>();
        services.AddScoped<EventService>();
        
        return services;
    }
}
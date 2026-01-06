using EventPilot.Application;
using EventPilot.Domain.ValueObjects;
using Mapster;

namespace EventPilot.Extensions;

/*
 * The father's name don't matter
 */
public static class AddPMappingExtension
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        
        TypeAdapterConfig.GlobalSettings.Scan(
            typeof(EventMappingConfig).Assembly
        );
        
        
        services.AddSingleton(TypeAdapterConfig.GlobalSettings);

        return services;
    }
}
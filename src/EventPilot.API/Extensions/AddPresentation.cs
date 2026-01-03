using System.Text.Json.Serialization;
using Mapster;

namespace EventPilot.Extensions;

/*
 * The father's name don't matter
 */
public static class AddPresentationExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }); 
        
        services.AddModelStateConfiguration();
        
        services.AddEndpointsApiExplorer(); 
        services.AddSwaggerGen();
        
        services.AddMapster();
        services.AddMapping(); // My mapping config

        return services;
    }
}
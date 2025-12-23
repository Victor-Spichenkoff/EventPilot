using System.Text.Json.Serialization;

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

        return services;
    }
}
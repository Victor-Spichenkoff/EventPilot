using System.Text.Json.Serialization;
using EventPilot.Infrastructure.Security;
using Mapster;

namespace EventPilot.Extensions;

/*
 * The father's name don't matter
 */
public static class AddPresentationExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // Auth
        services.AddAuth();


        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddModelStateConfiguration();


        services.AddMapster();
        services.AddMapping(); // My mapping config


        // Validation
        services
            .AddOptions<JwtSettings>()
            .BindConfiguration("Jwt")
            .Validate(o => !string.IsNullOrEmpty(o.Secret), "JWT Secret must be provided")
            .ValidateOnStart();


        return services;
    }
}

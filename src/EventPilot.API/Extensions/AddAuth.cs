using Microsoft.IdentityModel.Tokens;

namespace EventPilot.Extensions;

public static class AddAuthExtension
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false
                };
            });

        services.AddAuthorization();

        return services;
    }
}

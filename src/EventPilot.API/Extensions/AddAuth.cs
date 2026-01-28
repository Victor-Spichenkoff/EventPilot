using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EventPilot.Extensions;

public static class AddAuthExtension
{

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var secret = configuration["JwtSettings:Secret"];
        if(secret is null || secret.Length < 32)
            throw new ArgumentException("Invalid JWT secret.");

        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "EventApi",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secret)
                    )
                };
            });

        services.AddAuthorization();

        return services;
    }
}

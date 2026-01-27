
using EventPilot.Filters;
using Microsoft.OpenApi.Models;

namespace EventPilot.Extensions;

public static class AddSwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new() { Title = "EventPilot API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Inform a Token (just token): Bearer {seu_token}"
            });

            c.OperationFilter<SwaggerAuthorizeOperationFilter>();
        });


        return services;
    }
}

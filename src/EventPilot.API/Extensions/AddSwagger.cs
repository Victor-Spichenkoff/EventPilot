using Microsoft.OpenApi;


namespace EventPilot.Extensions;

public static class AddSwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            // c.SwaggerDoc("v1", new() { Title = "Minha API", Version = "v1" });
            //
            // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            // {
            //     Name = "Authorization",
            //     Type = SecuritySchemeType.Http,
            //     Scheme = "bearer",
            //     BearerFormat = "JWT",
            //     In = ParameterLocation.Header,
            //     Description = "Informe o token JWT no formato: Bearer {seu_token}"
            // });
            //
            // c.AddSecurityRequirement(document =>
            //     new OpenApiSecurityRequirement
            //     {
            //         {
            //             new OpenApiSecurityScheme
            //             {
            //                 Reference = new OpenApiReference
            //                 {
            //                     Type = ReferenceType.SecurityScheme,
            //                     Id = "Bearer"
            //                 }
            //             },
            //             Array.Empty<string>()
            //         }
            //     });
        });


        return services;
    }
}

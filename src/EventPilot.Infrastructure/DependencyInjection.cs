using EventPilot.Application.Interfaces.ExternarServices;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Infrastructure.Context;
using EventPilot.Infrastructure.Repositories;
using EventPilot.Infrastructure.Security;
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
        Console.WriteLine("==================\n\n\n");
        Console.WriteLine(config.GetConnectionString("Default"));
        Console.WriteLine("==================\n\n\n");



        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(config.GetConnectionString("Default")));



        //Repositories Here
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}

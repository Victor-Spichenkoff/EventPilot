using Microsoft.Extensions.DependencyInjection;
using RoomReservation.Application.Services;

namespace RoomReservation.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<TestService, TestService>();
        
        return services;
    }
}
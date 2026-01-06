using EventPilot.Application.Services;
using EventPilot.Application.Validators.Event;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EventPilot.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        //Services
        services.AddScoped<TestService>();
        services.AddScoped<EventService>();
        
        // it already registers all Validator from same assembly (application)
        services.AddValidatorsFromAssemblyContaining<CreateEventDtoValidator>();
        
        return services;
    }
}
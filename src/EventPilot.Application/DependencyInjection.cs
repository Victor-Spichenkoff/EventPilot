using EventPilot.Application.DTOs.Event;
using EventPilot.Application.Services;
using EventPilot.Application.Validators.Event;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventPilot.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        //Services
        services.AddScoped<TestService>();
        services.AddScoped<EventService>();
        services.AddScoped<AuthService>();
        
        // it already registers all Validator from same assembly (application)
        services.AddValidatorsFromAssemblyContaining<CreateEventDtoValidator>();
        // services.AddValidatorsFromAssemblyContaining<UpdateEventDtoValidator>();
        // services.AddValidatorsFromAssemblyContaining<PatchEventDtoValidator>();
        
        
        services.AddFluentValidationAutoValidation();
        
        return services;
    }
}
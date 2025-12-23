using System.Text.Json.Serialization;
using EventPilot.Application.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EventPilot.Extensions;

/*
 * The father's name don't matter
 */
public static class AdModelStateConfigurationExtension
{
    public static IServiceCollection AddModelStateConfiguration(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .Where(ms => ms.Value.Errors.Count > 0)
                    .Select(ms => new
                    {
                        Field = ms.Key,
                        Errors = ms.Value.Errors.Select(e => e.ErrorMessage)
                    });

                var response = new ErrorResponse
                {
                    Title = "validation_error",
                    Status = 400,
                    Instance = context.HttpContext.Request.Path.Value,
                    Errors = [..errors]
                };

                return new BadRequestObjectResult(response);
            };
        });

        return services;
    }
}
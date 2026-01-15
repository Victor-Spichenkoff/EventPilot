using FluentValidation;

namespace EventPilot.Application.Extensions;

/// <summary>
/// Default Error Message with format 'Inform a {PropertyName}'
/// </summary>
public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> IsRequired<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        string? message = null)
    {
        return ruleBuilder
            .NotNull()//TODO IS WORKING?
            .WithMessage(message ?? "Inform a {PropertyName}")
            .NotEmpty()
            .WithMessage(message ?? "Inform a {PropertyName}");
    }
}
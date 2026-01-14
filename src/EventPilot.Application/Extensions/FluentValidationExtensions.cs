using FluentValidation;

namespace EventPilot.Application.Extensions;


public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> IsRequired<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        string? message = null)
    {
        return ruleBuilder
            .NotNull()//TODO IS WORKING?
            .NotEmpty()
            .WithMessage(message ?? "Inform a {PropertyName}");
    }
}
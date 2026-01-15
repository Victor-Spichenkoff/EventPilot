using FluentValidation;

namespace EventPilot.Application.Extensions;

public static class UserEmaildValidationExtension
{
    public static IRuleBuilderOptions<T, string> EmailRules<T>(
        this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder
            .EmailAddress().WithMessage("Inform a valid email");
    }

}
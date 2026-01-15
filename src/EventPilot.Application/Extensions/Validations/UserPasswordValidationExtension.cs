using FluentValidation;

namespace EventPilot.Application.Extensions;

public static class UserPasswordValidationExtension
{
    public static IRuleBuilderOptions<T, string> PasswordRules<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        string? fieldName = "Password"
        )
    {
        return ruleBuilder
            .Matches(@"^\S+$").WithMessage($"{fieldName} can't contain white spaces")
            .MinimumLength(6).WithMessage($"{fieldName} must be at least 6 characters long")
            .MaximumLength(12).WithMessage($"{fieldName} can't be more than 12 characters long");
    }

}
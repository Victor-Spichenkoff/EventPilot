using FluentValidation;

namespace EventPilot.Application.Validators.User;

public class SignInDtoValidator: BaseUserValidator<SignInDtoValidator>
{
    public SignInDtoValidator()
    {
        RuleFor()
    }
}
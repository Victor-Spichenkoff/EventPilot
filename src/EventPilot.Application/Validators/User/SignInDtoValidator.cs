using EventPilot.Application.Extensions;
using FluentValidation;

namespace EventPilot.Application.Validators.User;

public class SignInDtoValidator: BaseUserValidator<SignInDto>
{
    public SignInDtoValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(2).WithMessage("Name must be at least 2 characters long")
            .MaximumLength(100).WithMessage("Name can't be more than 100 characters long")
            .IsRequired();
        
        RuleFor(x=> x.Password)
            .IsRequired();

        RuleFor(x => x.Email)
            .IsRequired();
        
        ValidateEmail();
        ValidatePassword();
    }
}
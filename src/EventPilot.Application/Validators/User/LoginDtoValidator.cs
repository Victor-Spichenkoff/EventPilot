using EventPilot.Application.Extensions;
using EventPilot.Application.Extensions.Validations;
using FluentValidation;

namespace EventPilot.Application.Validators.User;

public class LoginDtoValidator: BaseUserValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x=> x.Password)
            .IsRequired();

        RuleFor(x => x.Email)
            .IsRequired();
        
        ValidateEmail();
        ValidatePassword();
    }
}
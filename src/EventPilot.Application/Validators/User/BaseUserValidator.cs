using EventPilot.Application.DTOs.User;
using EventPilot.Application.Extensions;
using FluentValidation;

namespace EventPilot.Application.Validators.User;

public class BaseUserValidator<T>: AbstractValidator<T> where T : BaseUserDto
{
    protected void ValidateEmail()
    {
        RuleFor(x => x.Email)
            .EmailRules();
    }
    
    protected void ValidatePassword()
    {
        RuleFor(x => x.Password)
            .PasswordRules();
    }
    
}
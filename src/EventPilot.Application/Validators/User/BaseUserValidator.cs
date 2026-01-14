using System.ComponentModel.DataAnnotations;
using EventPilot.Application.DTOs.User;
using FluentValidation;

namespace EventPilot.Application.Validators.User;

public class BaseUserValidator<T>: AbstractValidator<T> where T : BaseUserDto
{
    protected void ValidateEmail()
    {
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Inform a valid email");
    }
    
    protected void ValidatePassword()
    {
        RuleFor(x => x.Password)
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .MaximumLength(12).WithMessage("Password can't be more than 12 characters long");
    }
    
}
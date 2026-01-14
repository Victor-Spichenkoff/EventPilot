using EventPilot.Application.DTOs.User;
using EventPilot.Application.Extensions;
using EventPilot.Domain.Enum;
using FluentValidation;

namespace EventPilot.Application.Validators.User;

public class PatchUserDtoValidator: BaseUserValidator<PatchUserDto>
{
    public PatchUserDtoValidator()
    {
        RuleFor(x => x.Role)
            .IsRequired()
            .IsInEnum();
        
        RuleFor(x => x.Name)
            .MinimumLength(2).WithMessage("Name must be at least 2 characters long")
            .MaximumLength(100).WithMessage("Name can't be more than 100 characters long");
        
        RuleFor(x=> x.Password)
            .IsRequired();

        RuleFor(x => x.Email)
            .IsRequired();
        
        
        ValidateEmail();
        ValidatePassword();
    }
}
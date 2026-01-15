using EventPilot.Application.DTOs.User;
using EventPilot.Application.Extensions;
using FluentValidation;

namespace EventPilot.Application.Validators.User;

public class UpdateUserPasswordValidator: AbstractValidator<UpdateUserPasswordDto>
{
    public UpdateUserPasswordValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .PasswordRules("Current Password")
            .IsRequired("Inform a current password");
        
        RuleFor(x => x.NewPassword)
            .PasswordRules("New Password")
            .IsRequired("Inform a new password");

        RuleFor(x => x.ConfirmNewPassword)
            .PasswordRules("Confirm new password")
            .IsRequired("Inform a new password confirmation");
    }
}
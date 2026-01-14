using EventPilot.Application.DTOs.User;
using FluentValidation;

namespace EventPilot.Application.Validators.User;

public class BaseUserValidator<T>: AbstractValidator<T> where T : BaseUserDto
{
    protected void ValidateName()
    {
        
    }
    
    protected void ValidateEmail()
    {
        
    }
    
    protected void ValidatePassword()
    {
        
    }
    
    protected void ValidateRole()
    {
        
    }
}
using EventPilot.Application.DTOs.Event;
using EventPilot.Application.Extensions;
using FluentValidation;

namespace EventPilot.Application.Validators.Event;

public class EventBaseDtoValidator<T> : AbstractValidator<T>
    where T : EventBaseDto
{
    protected void ValidateName()
    {
        RuleFor(x => x.Name)
            .MinimumLength(2).WithMessage("Name must be at least 2 characters long")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
    }
    
    protected void ValidateLocation()
    {
        RuleFor(x => x.Location)
            .MinimumLength(2).WithMessage("Location must be at least 2 characters long");
    }

    protected void ValidateDescription()
    {
        RuleFor(x => x.Description)
            .MaximumLength(250)
            .WithMessage("Description must be less than 250 characters");
    }
    
    protected void ValidateStatus()
    {
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status");
    }

    protected void ValidateEndDateBiggerThanStartDate()
    {
        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate).WithMessage("Start date can't be bigger than end date");
    }
    

    protected void SetRequiredFieldsValidationOn()
    {
        RuleFor(x => x.Name)
            .IsRequired();

        RuleFor(x => x.StartDate)
            .IsRequired("Inform a Start Date");

        RuleFor(x => x.EndDate)
            .IsRequired("Inform an End Date");
        
        RuleFor(x => x.Status)
            .IsRequired();
        
        // RuleFor(x => x.Name)
        //     .NotEmpty().WithMessage("Inform a name");
        //
        // RuleFor(x => x.StartDate)
        //     .NotEmpty().WithMessage("Inform a Start Date");
        //
        // RuleFor(x => x.EndDate)
        //     .NotEmpty().NotNull().WithMessage("Inform an End Date");
        //
        // RuleFor(x => x.Status)
        //     .NotEmpty().WithMessage("Inform a Status");
    }
}
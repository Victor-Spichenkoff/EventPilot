using EventPilot.Application.DTOs.Event;
using FluentValidation;

namespace EventPilot.Application.Validators.Event;

public class CreateEventDtoValidator: AbstractValidator<CreateEventDto>
{
    public CreateEventDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(x => x.Description)
            .MaximumLength(250)
            .WithMessage("Description must be less than 250 characters");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Inform a Start Date");
        
        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("Inform a End Date");
    }
}
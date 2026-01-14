using EventPilot.Application.DTOs.Event;
using EventPilot.Application.Validators.Event;
using EventPilot.Domain.Enum;
using Shouldly;

namespace UnitTests.DTOs;

public class EventDtoTest
{
    [Fact]
    public void Should_Be_Valid_When_All_Fields_Are_Filled()
    {
        var dto = CreateValidEventBaseEventDto();
        var validator = new EventBaseDtoValidator<EventBaseDto>();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Should_Be_Valid_When_Nullable_Fields_Are_Null()
    {
        var dto = (EventDto)CreateValidEventBaseEventDto();
        dto.Description = null;
        dto.TotalCapacity = null;
        var validator = new CreateEventDtoValidator();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeTrue();
    }


    [Fact]
    public void Should_Fail_When_StartDate_Is_In_Past()
    {
        var dto = (EventDto)CreateValidEventBaseEventDto();
        dto.StartDate = DateTime.Today.AddDays(-1);
        var validator = new CreateEventDtoValidator();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldContain(e => e.PropertyName == nameof(EventDto.StartDate));
        //containSingle -> Só 1 propriedade ([0]) e sendo assim
    }


    [Fact]
    public void Should_Fail_When_StartDate_Is_More_Than_EndDate()
    {
        var dto = (EventDto)CreateValidEventBaseEventDto();
        dto.StartDate = DateTime.Today.AddDays(10);
        dto.EndDate = DateTime.Today.AddDays(-10);
        var validator = new CreateEventDtoValidator();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeFalse();
        result.Errors
            .ShouldContain(e => e.PropertyName == nameof(EventDto.EndDate));
    }


    [Fact]
    public void Should_Pass_When_StartDate_Is_In_Past_And_Is_UpdateDto()
    {
        var dto = (UpdateEventDto)CreateValidEventBaseEventDto();
        dto.StartDate = DateTime.Today.AddDays(-10);

        var validator = new UpdateEventDtoValidator();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeTrue();
    }


    [Fact]
    public void Should_Pass_Fail_When_Dates_Are_Invalids_In_Patch()
    {
        var dto = CreateNullPatchEventDto();
        dto.StartDate = DateTime.Now.AddMinutes(1);
        dto.EndDate = DateTime.Now.AddDays(-10);

        var validator = new PatchEventDtoValidator();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldContain(e => e.PropertyName == nameof(PatchEventDto.EndDate));
    }

    // PATCH
    [Fact]
    public void Should_Pass_When_All_Fields_Are_Null()
    {
        var dto = CreateNullPatchEventDto();
            var validator = new PatchEventDtoValidator();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeTrue();
    }


    private static EventBaseDto CreateValidEventBaseEventDto()
    {
        return (EventBaseDto)(new UpdateEventDto()
        {
            Name = "Test",
            StartDate = DateTime.Now.AddMinutes(10),
            Description = "Test",
            Location = "Test",
            Status = (EventStatus?)1,
            EndDate = DateTime.Today.AddDays(1),
            TotalCapacity = 12
        });
    }

    private static PatchEventDto CreateNullPatchEventDto()
        => new PatchEventDto()
        {
            Name = null,
            Description = null,
            StartDate = null,
            EndDate = null,
            TotalCapacity = null,
            Location = null,
            Status = null,
            ClearDescription = null,
            ClearTotalCapacity = null,
        };
}
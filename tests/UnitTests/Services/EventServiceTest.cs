using EventPilot.Application.DTOs.Event;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Services;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Enum;
using Mapster;
// using FluentAssertions;
using Moq;
using Shouldly;

namespace UnitTests.Services;


[Collection("MapsterTests")]// avoids parallelism in tests with same group
public class EventServiceTest
{
    private static readonly DateTime Now = DateTime.Now;

    
    
    [Fact]
    public async Task  Should_Keep_Entity_Unchanged_When_All_Fields_Are_Null()
    {
        var originalEvent = GetNormalEvent();// creates a basic eventEntity with all fields filled
        var dto = new PatchEventDto();

        var repoMock = CreateMockAndSetGetByIdAndUpdate(originalEvent);
        
        var service = new EventService(repoMock.Object);
        
        // ACT
        var result = await service.PatchEventAsync(dto, 1);

        var unmodifiedEvent = GetNormalEvent();
        
        result.Id.ShouldBe(unmodifiedEvent.Id);
        result.Name.ShouldBe(unmodifiedEvent.Name);
        result.Description.ShouldBe(unmodifiedEvent.Description);
        result.Location.ShouldBe(unmodifiedEvent.Location);
        result.StartDate.ShouldBe(unmodifiedEvent.StartDate);
        result.EndDate.ShouldBe(unmodifiedEvent.EndDate);
        result.CreationDate.ShouldBe(unmodifiedEvent.CreationDate);
        result.TotalCapacity.ShouldBe(unmodifiedEvent.TotalCapacity);
        result.Status.ShouldBe(unmodifiedEvent.Status);
        
        repoMock.Verify(r => r.UpdateAsync(originalEvent), Times.Once);
    }
    
    /*
     * ClearDescription -> Must be allowed
     * totalCapacity = null -> should ignore, even though it's a valid nullable property
     */
    [Fact]
    public async Task  Should_Reset_Only_Allowed_Properties_With_Clear_Property()
    {
        var originalEvent = GetNormalEvent();// creates a basic eventEntity with all fields filled
        var dto = new PatchEventDto()
        {
            ClearDescription = true
        };

        var repoMock = CreateMockAndSetGetByIdAndUpdate(originalEvent);
        
        var service = new EventService(repoMock.Object);
        
        // ACT
        var result = await service.PatchEventAsync(dto, 1);

        var unmodifiedEvent = GetNormalEvent();
        
        result.Name.ShouldBe(unmodifiedEvent.Name);//not nullable
        result.Description.ShouldBe(null);//modified
        result.TotalCapacity.ShouldBe(unmodifiedEvent.TotalCapacity);// not modified, but nullable

        
        repoMock.Verify(r => r.UpdateAsync(originalEvent), Times.Once);
    }
    

    [Fact]
    public async Task  Should_Update_Without_Set_NunNullable_Property_ToNull()
    {
        var originalEvent = GetNormalEvent();// creates a basic eventEntity with all fields filled
        var newName = "This was updated";
        var dto = new PatchEventDto()
        {
            Name = newName,
            StartDate = null,
            Status = EventStatus.Cancelled
        };

        var repoMock = CreateMockAndSetGetByIdAndUpdate(originalEvent);
        
        var service = new EventService(repoMock.Object);
        
        // ACT
        var result = await service.PatchEventAsync(dto, 1);

        var unmodifiedEvent = GetNormalEvent();
        
        result.Name.ShouldBe(newName);
        result.Status.ShouldBe(EventStatus.Cancelled);
        result.StartDate.ShouldBe(unmodifiedEvent.StartDate);
        result.Location.ShouldBe(unmodifiedEvent.Location);//not modified
        
        repoMock.Verify(r => r.UpdateAsync(originalEvent), Times.Once);
    }


    private static Event GetNormalEvent()
    => new Event()
        {
            Id = 1,
            Name = "My Event",
            Location = "Bahamas",
            Description = "Test Event",
            StartDate = Now.AddHours(1),
            EndDate = Now.AddHours(10),
            CreationDate = Now,
            TotalCapacity = 1000,
            Status = EventStatus.Published,
        };

    private static Mock<IEventRepository> CreateMockAndSetGetByIdAndUpdate(Event originalEvent)
    {
        var repoMock = new Mock<IEventRepository>();
        repoMock.Setup(r => r.GetByIdAsync(It.IsAny<long>()))
            .ReturnsAsync(originalEvent);
        
        repoMock.Setup(r => r.UpdateAsync(It.IsAny<Event>()))
            .ReturnsAsync((Event e) => e);
        
        return repoMock;
    }
    
}
using EventPilot.Application.DTOs.Event;
using EventPilot.Application.Services;
using IntegrationTest.ApiFactories;
using IntegrationTest.Helpers.Entities;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace IntegrationTest.Services;

public class EventPatchServiceTest : IClassFixture<EventServiceApiFactory>
{
    private readonly EventServiceApiFactory _factory;


    public EventPatchServiceTest(EventServiceApiFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Patch_Should_Ignore_All_Null_Values()
    {
        // Arrange
        // var service = GetEventService();
        using var scope = _factory.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<EventService>();
        
        var dto = new PatchEventDto();

        // Act
        var result = await service.PatchEventAsync(dto, 1);

        // Assert
        var defaultEntity = EventHelper.GetStockEvent();

        result.Name.ShouldBe(defaultEntity.Name);
        result.Description.ShouldBe(defaultEntity.Description);
        result.StartDate.ShouldBe(defaultEntity.StartDate);
    }

    [Fact]
    public async Task Patch_Should_Set_Only_Nullable_Properties_To_Null()
    {
        // Arrange
        // var service = GetEventService();
        using var scope = _factory.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<EventService>();

        var dto = new PatchEventDto()
        {
            ClearDescription = true,
            TotalCapacity = null,
            Name = null
        };

        // Act
        var result = await service.PatchEventAsync(dto, 1);

        // Assert
        var defaultEntity = EventHelper.GetStockEvent();

        result.Name.ShouldBe(defaultEntity.Name);
        result.Description.ShouldBe(null);
        result.TotalCapacity.ShouldBe(defaultEntity.TotalCapacity);
    }
    
    
    [Fact]
    public async Task Patch_Should_Set_Only_Nullable_Properties_To_Null_2()
    {
        // Arrange
        // var service = GetEventService();
        using var scope = _factory.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<EventService>();

        var dto = new PatchEventDto()
        {
            ClearDescription = true,
            TotalCapacity = null,
            Name = null
        };

        // Act
        var result = await service.PatchEventAsync(dto, 1);

        // Assert
        var defaultEntity = EventHelper.GetStockEvent();

        result.Name.ShouldBe(defaultEntity.Name);
        result.Description.ShouldBe(null);
        result.TotalCapacity.ShouldBe(defaultEntity.TotalCapacity);
    }


    // Helper
    // private EventService GetEventService()
    // {
    //     using var scope = _factory.Services.CreateScope();
    //     var service = scope.ServiceProvider.GetRequiredService<EventService>();
    // }
}
using EventPilot.Application.DTOs.Event;
using EventPilot.Domain.Entities;
using Mapster;

namespace IntegrationTest.Fixtures;

public class MapsterFixture
{
    public MapsterFixture()
    {
        // It runs only once
        TypeAdapterConfig.GlobalSettings
            .NewConfig<PatchEventDto, Event>()
            .IgnoreNullValues(true);
    }
}
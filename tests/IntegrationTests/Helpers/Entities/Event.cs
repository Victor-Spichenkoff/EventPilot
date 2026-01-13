using EventPilot.Domain.Entities;
using EventPilot.Domain.Enum;

namespace IntegrationTest.Helpers.Entities;

public static class EventHelper
{
    private static readonly DateTime Now = DateTime.Now;
    
    public static Event GetStockEvent()
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
}
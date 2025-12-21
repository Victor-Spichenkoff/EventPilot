using EventPilot.Domain.Enum;

namespace EventPilot.Domain.Entities;

public class Event
{
    public long Id { get; set; }
    public required string Name {get; set;}
    public required string Location {get; set;}
    public string? Description {get; set;}
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? TotalCapacity { get; set; }
    public EventStatus Status { get; set; }
    public DateTime CreationDate { get; set; }
    
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
    public ICollection<EventRegistration> EventRegistrations { get; set; } = null!;
    public ICollection<OrganizerEvent> OrganizerEvents { get; set; } = new List<OrganizerEvent>();
}
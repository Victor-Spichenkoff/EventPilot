using EventPilot.Domain.Enum;

namespace EventPilot.Application.DTOs.Responses;

public class EventResponseDto
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
}
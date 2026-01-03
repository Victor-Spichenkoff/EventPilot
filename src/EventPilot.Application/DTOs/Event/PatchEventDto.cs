using System.ComponentModel.DataAnnotations;
using EventPilot.Domain.Enum;
using EventPilot.Domain.ValueObjects;

namespace EventPilot.Application.DTOs.Event;

public class PatchEventDto
{
    public Optional<string> Name {get; set;}
    
    public Optional<string> Location {get; set;}
    
    public Optional<string> Description {get; set;}
    public Optional<bool> ClearDescription { get; set; }
    
    public Optional<DateTime> StartDate { get; set; }
    
    public Optional<DateTime> EndDate { get; set; }
    
    public Optional<int> TotalCapacity { get; set; }
    public Optional<bool> ClearTotalCapacity { get; set; }
    
    public Optional<EventStatus> Status { get; set; }
}
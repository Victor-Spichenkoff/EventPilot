using System.ComponentModel.DataAnnotations;
using EventPilot.Domain.Enum;
using EventPilot.Domain.ValueObjects;

namespace EventPilot.Application.DTOs.Event;

public class PatchEventDto
{
    public string? Name {get; set;}
    
    public string? Location {get; set;}
    
    public string? Description {get; set;}
    public bool ClearDescription { get; set; } = false;
    
    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public int? TotalCapacity { get; set; }
    public bool ClearTotalCapacity { get; set; } = false;
    
    public EventStatus? Status { get; set; }
}
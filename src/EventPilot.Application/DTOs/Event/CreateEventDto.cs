using System.ComponentModel.DataAnnotations;
using EventPilot.Domain.Enum;

namespace EventPilot.Application.DTOs.Event;

public class CreateEventDto
{
    public required string Name { get; set; }


    public required string Location { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime StartDate { get; set; }


    public DateTime EndDate { get; set; }

    public int? TotalCapacity { get; set; }


    public EventStatus Status { get; set; }
}


// public class CreateEventDto
// {
//     [Required(ErrorMessage = "Name is required")]
//     public required string Name {get; set;}
//     
//     [Required(ErrorMessage = "Name is required")]
//     public required string Location {get; set;}
//     
//     [MaxLength(250, ErrorMessage = "Description can't be more than 250 characters")]
//     public string? Description {get; set;}
//     
//     [Required(ErrorMessage = "Start date is required")]
//     public DateTime StartDate { get; set; }
//     
//     [Required(ErrorMessage = "End date is required")]
//     public DateTime EndDate { get; set; }
//     
//     public int? TotalCapacity { get; set; }
//     
//     [Required(ErrorMessage = "Status is required")]
//     public EventStatus Status { get; set; }
// }
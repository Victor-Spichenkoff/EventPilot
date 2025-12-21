using EventPilot.Application.DTOs.Event;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Services;
using EventPilot.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPilot.Controllers;


[ApiController]
[Route("[controller]")]
public class EventController(EventService eventService): Controller
{
    private readonly EventService _eventService = eventService;
    
    [HttpGet]
    public ICollection<Event> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _eventService.GetEventAsync(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEventDto eventDto)
    {
        var createdEvent = await _eventService.CreateEventAsync(eventDto);
        return Ok(createdEvent);
    }
}
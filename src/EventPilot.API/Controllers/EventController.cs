using EventPilot.Application.DTOs.Event;
using EventPilot.Application.DTOs.Responses;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Services;
using EventPilot.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EventPilot.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController(EventService eventService) : ControllerBase
{
    private readonly EventService _eventService = eventService;

    [HttpGet]
    public ICollection<Event> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventResponseDto>> GetEventById(long id)
    => Ok(await _eventService.GetEventAsync(id));
    

    
    [ProducesResponseType(typeof(EventResponseDto), 200)]
    [HttpPost]
    public async Task<ActionResult<EventResponseDto>> CreateEvent([FromBody] CreateEventDto eventDto)
    {
        var createdEvent = await _eventService.CreateEventAsync(eventDto);
        return Ok(createdEvent.Adapt<EventResponseDto>());
    }
}
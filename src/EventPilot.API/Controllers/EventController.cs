using EventPilot.Application.DTOs.Event;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Services;
using EventPilot.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPilot.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(EventService eventService) : ControllerBase
{
    private readonly EventService _eventService = eventService;

    [HttpGet]
    public ICollection<Event> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventById(long id)
    {
        if (id == 1)
            return NotFound("Não encontrado");
        
        return Ok(await _eventService.GetEventAsync(id));
    }


    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto eventDto)
    {
        return Ok(await _eventService.CreateEventAsync(eventDto));
    }
}
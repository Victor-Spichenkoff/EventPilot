using EventPilot.Application.DTOs.Event;
using EventPilot.Application.DTOs.Responses;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Services;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EventPilot.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(EventService eventService) : ControllerBase
// public class EventsController(EventService eventService) : ControllerBase
{
    // private readonly EventService _eventService = eventService;
    


    // [ProducesResponseType(typeof(EventResponseDto), 200)]
    // [HttpPost]
    // public async Task<ActionResult<EventResponseDto>> CreateEvent([FromBody] EventDto eventDto)
    // {
    //     return Ok(await _eventService.CreateEventAsync(eventDto));
    // }

    
}
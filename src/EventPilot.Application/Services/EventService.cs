using EventPilot.Application.DTOs.Event;
using EventPilot.Application.DTOs.Responses;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Exceptions;
using Mapster;

namespace EventPilot.Application.Services;

public class EventService(IEventRepository eventRepository)
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<EventResponseDto> GetEventAsync(long id)
    {
        var eventFromDb = await _eventRepository.GetByIdAsync(id);
        if (eventFromDb is null) 
            throw new NotFoundException("Event not found");
        
        return eventFromDb.Adapt<EventResponseDto>();
    }

    public async Task<Event?>  CreateEventAsync(CreateEventDto dto)
    {
        //TODO
        var eventToCreate = dto.Adapt<Event>();
        return await _eventRepository.CreateAsync(eventToCreate);
    }
}
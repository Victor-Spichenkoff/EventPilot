using EventPilot.Application.DTOs.Event;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Exceptions;

namespace EventPilot.Application.Services;

public class EventService(IEventRepository eventRepository)
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<Event> GetEventAsync(long id)
    {
        var eventFromDb = await _eventRepository.GetByIdAsync(id);
        if (eventFromDb is null) 
            throw new NotFoundException("Event not found");
        
        return eventFromDb;
    }

    public async Task<Event?> CreateEventAsync(CreateEventDto dto)
    {
        //TODO
        return await _eventRepository.GetByIdAsync(1);
        // return await _eventRepository.CreateAsync(entity);
    }
}
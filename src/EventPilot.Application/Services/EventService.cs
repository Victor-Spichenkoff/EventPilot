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

    public async Task<ICollection<EventResponseDto>> GetPaged(int page=0, int pageSize = 10)
    {
        var events = await _eventRepository.Get(page, pageSize);
        return events.Adapt<ICollection<EventResponseDto>>();
    }
    
    public async Task<EventResponseDto> GetEventAsync(long id)
    {
        var eventFromDb = await _eventRepository.GetByIdAsync(id);
        if (eventFromDb is null) 
            throw new NotFoundException("Event not found");
        
        return eventFromDb.Adapt<EventResponseDto>();
    }

    public async Task<EventResponseDto?>  CreateEventAsync(CreateEventDto dto)
    {
        //TODO
        var eventToCreate = dto.Adapt<Event>();
        var createdEvent = await _eventRepository.CreateAsync(eventToCreate);
        return createdEvent.Adapt<EventResponseDto>();
    }

    public async Task<EventResponseDto> UpdateEventAsync(UpdateEventDto eventDto, long id)
    {
        var eventToUpdate = await _eventRepository.GetByIdAsync(id);
        if(eventToUpdate == null)
            throw new NotFoundException("Event not found");
        
        var newEvent = eventDto.Adapt(eventToUpdate);
        if(newEvent == null)
            throw new BusinessException("Can't update event");
        
        // Clear situations
        if(eventDto.ClearTotalCapacity == true)
            newEvent.TotalCapacity = null;
        if(eventDto.ClearDescription == true)
            newEvent.Description = null;    

        var updateEvent = await _eventRepository.UpdateAsync(newEvent);
        return updateEvent.Adapt<EventResponseDto>();
    }
    
    public async Task<EventResponseDto> PatchEventAsync(PatchEventDto eventDto, long id)
    {
        var eventToUpdate = await _eventRepository.GetByIdAsync(id);
        if(eventToUpdate == null)
            throw new NotFoundException("Event not found");
        
        // var newEvent =  eventDto.Adapt(eventToUpdate);
        eventDto.Adapt(eventToUpdate);
        if(eventToUpdate == null)
            throw new BusinessException("Can't update event");
        
        // Clear situations
        if(eventDto.ClearTotalCapacity == true)
            eventToUpdate.TotalCapacity = null;
        if(eventDto.ClearDescription == true)
            eventToUpdate.Description = null;

        var updateEvent = await _eventRepository.UpdateAsync(eventToUpdate);
        return updateEvent.Adapt<EventResponseDto>();
    }
}
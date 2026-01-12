using EventPilot.Application.DTOs.Event;
using EventPilot.Application.DTOs.Responses;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Enum;
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

    public async Task<EventResponseDto>  CreateEventAsync(EventDto eventDto)
    {
        ValidateStatusEnum(eventDto.Status);
        
        var eventToCreate = eventDto.Adapt<Event>();
        var createdEvent = await _eventRepository.CreateAsync(eventToCreate);
        
        if(createdEvent is null)
            throw new InternalServerException("Can't create event");
        
        return createdEvent.Adapt<EventResponseDto>();
    }

    public async Task<EventResponseDto> UpdateEventAsync(UpdateEventDto eventDto, long id)
    {
        var eventToUpdate = await _eventRepository.GetByIdAsync(id);
        if(eventToUpdate == null)
            throw new NotFoundException("Event not found");
        ValidateStatusEnum(eventDto.Status);
        
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
        if(eventDto.Status is not null)
            ValidateStatusEnum(eventDto.Status);
        
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

    public async Task<bool> DeleteEventAsync(long id)
    {
        var eventToDelete = await _eventRepository.GetByIdAsync(id);
        
        if(eventToDelete is null)
            throw new NotFoundException("Event not found");
        
        return await _eventRepository.DeleteByIdAsync(eventToDelete);
    }
    

    // Support
    private void ValidateStatusEnum(EventStatus? status)
    {
        if (status==null || !Enum.IsDefined(typeof(EventStatus), status))
            throw new BusinessException("Invalid Status");
    }
}
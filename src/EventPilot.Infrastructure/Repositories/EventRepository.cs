using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Enum;
using EventPilot.Infrastructure.Context;

namespace EventPilot.Infrastructure.Repositories;

public class EventRepository(AppDbContext context) : IEventRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Event?> GetByIdAsync(long id)
    {
        return await _context.Events.FindAsync(id);
    }

    public async Task<Event> CreateAsync(Event entity)
    {
        var createdEntity = await _context.Events.AddAsync(entity);
        var result = await _context.SaveChangesAsync();
        return createdEntity.Entity;
    }

    public Task<Event> UpdateAsync(Event entity)
    {
        throw new NotImplementedException();
    }

    public bool DeleteByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Event>> Get(int? page, int? pageSize, int? skip)
    {
        throw new NotImplementedException();
    }
}
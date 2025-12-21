using EventPilot.Domain.Entities;

namespace EventPilot.Application.Interfaces.Repositories;

public interface IRepository<T>
{
    public Task<Event?> GetByIdAsync(long id);
    
    public Task<T> CreateAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public bool DeleteByIdAsync(long id);
}
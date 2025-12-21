using EventPilot.Domain.Entities;

namespace EventPilot.Application.Interfaces.Repositories;

public interface IEventRepository: IRepository<Event>
{
    public Task<ICollection<Event>> Get(int? page, int? pageSize, int? skip);
}
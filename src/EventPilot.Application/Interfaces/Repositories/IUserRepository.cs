using EventPilot.Domain.Entities;

namespace EventPilot.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetUserByEmail(string email);
    
}
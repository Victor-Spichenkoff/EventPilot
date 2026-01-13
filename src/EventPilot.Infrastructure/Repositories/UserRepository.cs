using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Exceptions;
using EventPilot.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EventPilot.Infrastructure.Repositories;

public class UserRepository(AppDbContext context): IUserRepository
{
    private readonly AppDbContext _context = context;
   

    public User? GetByIdUser(long id)
    {
        throw new NotImplementedException();
    }

    public User Update(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateAsync(User user)
    {
        var createdUser = _context.Users.Add(user);
        var isSuccess = await _context.SaveChangesAsync() > 0;
        if (!isSuccess)
            throw new InternalServerException("Can't create user");
        
        return createdUser.Entity;
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
    }
}
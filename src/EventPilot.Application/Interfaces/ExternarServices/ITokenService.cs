using EventPilot.Domain.Entities;

namespace EventPilot.Application.Interfaces.ExternarServices;

public interface ITokenService
{
    string GenerateToken(User user);

}
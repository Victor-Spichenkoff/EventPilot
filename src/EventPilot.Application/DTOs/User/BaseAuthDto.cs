using EventPilot.Domain.Enum;

namespace EventPilot.Application.DTOs.User;

public class BaseAuthDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string Password { get; set; } = String.Empty;
}
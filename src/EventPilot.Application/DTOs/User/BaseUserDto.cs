using EventPilot.Domain.Enum;

namespace EventPilot.Application.DTOs.User;

public class BaseUserDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string Password { get; set; } = String.Empty;
    public Roles Role { get; set; } = Roles.User;
}
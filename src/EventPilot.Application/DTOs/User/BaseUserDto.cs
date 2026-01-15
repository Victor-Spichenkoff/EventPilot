using EventPilot.Domain.Enum;

namespace EventPilot.Application.DTOs.User;

public class BaseUserDto
{
    public string Email { get; set; }
    public string Password { get; set; } = String.Empty;
}
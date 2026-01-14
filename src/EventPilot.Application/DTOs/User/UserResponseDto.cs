using EventPilot.Domain.Enum;

namespace EventPilot.Application.Validators.User;

public class UserResponseDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public Roles Role { get; set; }
}
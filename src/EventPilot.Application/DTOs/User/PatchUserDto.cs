using EventPilot.Application.Validators.User;
using EventPilot.Domain.Enum;

namespace EventPilot.Application.DTOs.User;

public class PatchUserDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public Roles? Role { get; set; }
}
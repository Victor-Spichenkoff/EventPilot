using EventPilot.Application.Validators.User;
using EventPilot.Domain.Enum;

namespace EventPilot.Application.DTOs.User;

public class PatchUserDto: SignInDto
{
    public Roles? Role { get; set; }
}
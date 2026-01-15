using EventPilot.Application.DTOs.User;

namespace EventPilot.Application.Validators.User;

public class SignInDto: BaseUserDto
{
    public string Name { get; set; }
}
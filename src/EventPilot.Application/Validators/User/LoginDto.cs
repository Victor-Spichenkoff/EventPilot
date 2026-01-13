namespace EventPilot.Application.Validators.User;

public class LoginDto: SignInDto
{
    public required string Name { get; set; }
}
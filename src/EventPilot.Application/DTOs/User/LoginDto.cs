namespace EventPilot.Application.Validators.User;

public class LoginDto
{
    public required string Name { get; set; }
    
    public required string Email { get; set; }
    
    public required string Password { get; set; }
}
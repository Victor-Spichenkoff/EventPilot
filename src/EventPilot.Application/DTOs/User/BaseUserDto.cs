using System.ComponentModel;
using EventPilot.Domain.Enum;
using Swashbuckle.AspNetCore.Annotations;

namespace EventPilot.Application.DTOs.User;

public class BaseUserDto
{
    [DefaultValue("user@mail.com")]
    public string Email { get; set; }
    
    [DefaultValue("123456")]   
    public string Password { get; set; } = String.Empty;
}
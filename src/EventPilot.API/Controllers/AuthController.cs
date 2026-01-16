using EventPilot.Application.DTOs.Responses;
using EventPilot.Application.DTOs.User;
using EventPilot.Application.Services;
using EventPilot.Application.Validators.User;
using Microsoft.AspNetCore.Mvc;

namespace EventPilot.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(AuthService authService) : ControllerBase
{
    private readonly AuthService _authService = authService;
    


    [ProducesResponseType(typeof(TokenResponse), 200)]
    [HttpPost("login")]
    public async Task<ActionResult<TokenResponse>> CreateEvent([FromBody] LoginDto loginDto)
    {
        return Ok(await _authService.Login(loginDto));
    }

    
    [ProducesResponseType(typeof(UserResponseDto), 200)]
    [HttpPost("signin")]
    public async Task<ActionResult<EventResponseDto>> CreateEvent([FromBody] SignInDto loginDto)
    {
        return Ok(await _authService.CreateUser(loginDto));
    }
    
    
    
    [ProducesResponseType(typeof(string), 200)]
    [HttpPatch("password/{userId}")]
    public async Task<ActionResult<EventResponseDto>> UpdatePassword([FromBody] UpdateUserPasswordDto updateUserPasswordDto, long userId)
    {
        await _authService.UpdateUserPassword(userId, updateUserPasswordDto);
        return Ok("Password updated");
    }
}
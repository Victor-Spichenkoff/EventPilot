using System.Security.Claims;
using EventPilot.Application.DTOs.Responses;
using EventPilot.Application.DTOs.User;
using EventPilot.Application.Services;
using EventPilot.Application.Validators.User;
using EventPilot.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
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


    [Authorize]
    [ProducesResponseType(typeof(string), 200)]
    [HttpPatch("password/{userId}")]
    // [HttpPatch("password/{userId}")]
    // public async Task<ActionResult<EventResponseDto>> UpdatePassword([FromBody] UpdateUserPasswordDto updateUserPasswordDto, long userId)
    public async Task<ActionResult<EventResponseDto>> UpdatePassword([FromBody] UpdateUserPasswordDto updateUserPasswordDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            throw new UnauthorizedException("You are not logged in");
        await _authService.UpdateUserPassword(int.Parse(userId), updateUserPasswordDto);
        return Ok("Password updated");
    }
}

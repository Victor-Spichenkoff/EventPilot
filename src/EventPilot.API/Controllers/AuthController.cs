using EventPilot.Application.DTOs.Event;
using EventPilot.Application.DTOs.Responses;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Services;
using EventPilot.Application.Validators.User;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EventPilot.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(AuthService authService) : ControllerBase
{
    private readonly AuthService _authService = authService;
    


    // [ProducesResponseType(typeof(EventResponseDto), 200)]
    // [HttpPost("login")]
    // public async Task<ActionResult<EventResponseDto>> CreateEvent([FromBody] LoginDto loginDto)
    // {
    //     return Ok(await _authService.Login(loginDto));
    // }

    
    [ProducesResponseType(typeof(UserResponseDto), 200)]
    [HttpPost("signin")]
    public async Task<ActionResult<EventResponseDto>> CreateEvent([FromBody] SignInDto loginDto)
    {
        return Ok(await _authService.CreateUser(loginDto));
    }
}
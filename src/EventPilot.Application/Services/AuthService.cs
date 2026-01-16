using EventPilot.Application.DTOs.User;
using EventPilot.Application.Interfaces.ExternarServices;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Validators.User;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Exceptions;
using Mapster;
using Microsoft.Extensions.Configuration;

namespace EventPilot.Application.Services;

public class AuthService(
    IPasswordHashService passwordHashService, 
    IUserRepository userRepository,
        ITokenService tokenService,
    IConfiguration configuration)
{
    private readonly IPasswordHashService _passwordHashService = passwordHashService;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IConfiguration _configuration = configuration;

    public async Task<TokenResponse> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByEmail(loginDto.Email);
        if (user is null)
            throw new BusinessException("Invalid email");
        
        if(!_passwordHashService.Verify(loginDto.Password,user.Password))
            throw new BusinessException("Invalid password");
        
        var token = _tokenService.GenerateToken(user);
        var expiresInHours = _configuration["JwtSettings:ExpirationHours"] ?? "0";
        var expiresAt = DateTime.Now.AddHours(Double.Parse(expiresInHours));
        
        return new TokenResponse()
        {
            Token = token,
            ExpiresAt = expiresAt,
        };
    }


    public async Task<UserResponseDto?> CreateUser(SignInDto signInDto)
    {
        var user = await _userRepository.GetUserByEmail(signInDto.Email);
        if(user is not null)
            throw new BusinessException("Email already taken");
        
        signInDto.Password = _passwordHashService.Hash(signInDto.Password);
        var newUser = signInDto.Adapt<User>();
        
        var createdUser = await _userRepository.CreateAsync(newUser);
        
        return createdUser.Adapt<UserResponseDto>();
    }


    public async Task<bool> UpdateUserPassword(long userId, UpdateUserPasswordDto updatePasswordDto)
    {
        if(updatePasswordDto.NewPassword != updatePasswordDto.ConfirmNewPassword)
            throw new BusinessException("Passwords do not match");

        var user = await _userRepository.GetByIdAsync(userId);
        if(user is null)
            throw new NotFoundException("User not found");
        
        if(!_passwordHashService.Verify(updatePasswordDto.CurrentPassword, user.Password))
            throw new BusinessException("Wrong password");
        
        user.Password = _passwordHashService.Hash(updatePasswordDto.NewPassword);
        await _userRepository.UpdateAsync(user);

        return true;
    }
}
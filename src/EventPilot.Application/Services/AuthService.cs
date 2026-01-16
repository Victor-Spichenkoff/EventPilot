using EventPilot.Application.DTOs.User;
using EventPilot.Application.Interfaces.ExternarServices;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Validators.User;
using EventPilot.Domain.Entities;
using EventPilot.Domain.Exceptions;
using Mapster;

namespace EventPilot.Application.Services;

public class AuthService(IPasswordHashService passwordHashService, IUserRepository userRepository)
{
    private readonly IPasswordHashService _passwordHashService = passwordHashService;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<bool> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByEmail(loginDto.Email);
        if (user is null)
            throw new BusinessException("Invalid email");
        
        if(!_passwordHashService.Verify(loginDto.Password,user.Password))
            throw new BusinessException("Invalid password");
        
        
        return true;
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
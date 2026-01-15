using EventPilot.Application.Interfaces.ExternarServices;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Validators.User;
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
            throw new BusinessException("Invalid email or password");
        
        if(!_passwordHashService.Verify(loginDto.Password,user.Password))
            throw new BusinessException("Invalid email or password");
        
        
        return true;
    }


    public async Task<UserResponseDto?> CreateUser(SignInDto signInDto)
    {
        var user = await _userRepository.GetUserByEmail(signInDto.Email);
        if(user is null)
            throw new BusinessException("Email already taken");
        
        user.Password = _passwordHashService.Hash(signInDto.Password);

        var createdUser = await _userRepository.CreateAsync(user);
        
        return user.Adapt<UserResponseDto>();
    }
}
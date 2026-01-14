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

    public void Login(LoginDto loginDto)
    {
        
    }


    public async Task<UserResponseDto?> CreateUser(SignInDto signInDto)
    {
        var user = await _userRepository.GetUserByEmail(signInDto.Email);
        if(user is not null)
            throw new BusinessException("Email already taken");
        
        var password = _passwordHashService.Hash(signInDto.Password);

        return user.Adapt<UserResponseDto>();
    }
}
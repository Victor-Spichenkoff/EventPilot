using EventPilot.Application.Interfaces.ExternarServices;
using EventPilot.Application.Interfaces.Repositories;
using EventPilot.Application.Validators.User;
using EventPilot.Domain.Exceptions;

namespace EventPilot.Application.Services;

public class AuthService(IPasswordHashService passwordHashService, IUserRepository userRepository)
{
    private readonly IPasswordHashService _passwordHashService = passwordHashService;
    private readonly IUserRepository _userRepository = userRepository;

    public void Login(LoginDto loginDto)
    {
        
    }


    public void CreateUser(SignInDto signInDto)
    {
        var user = _userRepository.GetUserByEmail(signInDto.Email);
        if(user is not null)
            throw new BusinessException("Email already taken");
    }
}

using EventPilot.Application.DTOs.User;

using EventPilot.Application.Validators.User;
using EventPilot.Domain.Enum;
using Shouldly;

namespace UnitTests.DTOs;

public class AuthDtoTests
{
    [Fact]
    public void Should_Be_Valid_When_All_Fields_Are_Filled_Correctly_In_Patch()
    {
        var dto = CreateValidPatchUserDto();
        var validator = new PatchUserDtoValidator();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeTrue();
    }
    
    [Fact]
    public void Should_Be_Valid_When_All_Fields_Are_Filled_Correctly_In_SignIn()
    {
        var dto = CreateValidSignInDto();
        var validator = new SignInDtoValidator();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeTrue();
    }
    
    [Fact]
    public void Should_Be_Valid_When_All_Fields_Are_Filled_Correctly_In_Login()
    {
        var dto = CreateValidLoginDto();
        var validator = new LoginDtoValidator();

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeTrue();
    }
    
    // ERROS
    [Fact]
    public void Should_Be_Fail_When_Email_Is_Not_Valid()
    {
        var dto = CreateValidLoginDto();
        dto.Email = "victor@";
        
        var validator = new LoginDtoValidator();
        

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeFalse();
        result.Errors
            .ShouldContain(e => e.PropertyName == nameof(LoginDto.Email));
    }

    
    [Fact]
    public void Should_Be_Fail_When_PasswordIs_Not_Valid()
    {
        var dto = CreateValidLoginDto();
        dto.Password = "12345";
        
        var validator = new LoginDtoValidator();
        

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeFalse();
        result.Errors
            .ShouldContain(e => e.PropertyName == nameof(LoginDto.Password));
    }
    
    [Fact]
    public void Should_Be_Fail_When_Fields_Are_Not_Filled_Correctly_In_SignIn()
    {
        var dto = CreateValidSignInDto();
        dto.Name = "a";
        dto.Email = "victor@";
        dto.Password = "agfdsgswe5t5 htb5e4be4e4e";
        
        var validator = new SignInDtoValidator();
        

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeFalse();
        result.Errors
            .ShouldContain(e => e.PropertyName == nameof(SignInDto.Name));
        result.Errors
            .ShouldContain(e => e.PropertyName == nameof(SignInDto.Email));
        result.Errors
            .ShouldContain(e => e.PropertyName == nameof(SignInDto.Password));
    }
    
    
    
    [Fact]
    public void Should_Be_Fail_When_Fields_Are_Not_Filled_In_SignIn()
    {
        var dto = CreateValidSignInDto();
        dto.Name = null;
        dto.Email = null;
        dto.Password = null;
        
        var validator = new SignInDtoValidator();
        

        var result = validator.Validate(dto);

        result.IsValid.ShouldBeFalse();
        result.Errors
            .ShouldContain(e => e.PropertyName == nameof(SignInDto.Name));
        result.Errors
            .ShouldContain(e => e.PropertyName == nameof(SignInDto.Email));
        result.Errors
            .ShouldContain(e => e.PropertyName == nameof(SignInDto.Password));
    }
    
    
    private static PatchUserDto CreateValidPatchUserDto()
        => new PatchUserDto()
        {
            Name = "Victor",
            Email = "Victor@gmail",
            Role = Roles.Admin
        };
    
    
    private static LoginDto CreateValidLoginDto()
        => new LoginDto()
        {
            Email = "Victor@gmail",
            Password = "123456",
        };
    
    private static SignInDto CreateValidSignInDto()
        => new SignInDto()
        {
            Name = "Victor",
            Email = "Victor@gmail",
            Password = "123456",
        };
}
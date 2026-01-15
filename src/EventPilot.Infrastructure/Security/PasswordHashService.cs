using EventPilot.Application.Interfaces.ExternarServices;
using Microsoft.AspNetCore.Identity;

namespace EventPilot.Infrastructure.Security;

public class PasswordHashService: IPasswordHashService
{
    private readonly PasswordHasher<object> _hasher;

    public PasswordHashService()
    {
        _hasher = new PasswordHasher<object>();
    }

    public string Hash(string password)
    {
        return _hasher.HashPassword(null, password);
    }

    public bool Verify(string? password, string passwordHash)
    {
        var result = _hasher.VerifyHashedPassword(
            null,
            passwordHash,
            password
        );

        return result == PasswordVerificationResult.Success;
    }
}
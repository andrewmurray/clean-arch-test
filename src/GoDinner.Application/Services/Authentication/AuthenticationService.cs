using GoDinner.Application.Common.Interfaces.Authentication;

namespace GoDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        Guid userId = Guid.NewGuid();

        var token = _tokenGenerator.Generate(userId, firstName, lastName);

        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "", "", email, "token");
    }
}


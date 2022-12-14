using GoDinner.Application.Services.Authentication;
using GoDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GoDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return Ok(new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = _authenticationService.Login(request.Email, request.Password);
        return Ok(new AuthenticationResponse(result.Id, result.FirstName, result.LastName, result.Email, result.Token));
    }
}

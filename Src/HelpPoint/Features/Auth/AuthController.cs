using HelpPoint.Infrastructure.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Features.Auth;

[ApiController]
[Route("api/v1/auth")]
public class AuthController(IAuth auth) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginRequest loginRequest)
    {
        var result = await auth.LoginAsync(loginRequest);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
    {
        var result = await auth.RefreshTokenAsync(refreshTokenRequest);
        return Ok(result);
    }
}

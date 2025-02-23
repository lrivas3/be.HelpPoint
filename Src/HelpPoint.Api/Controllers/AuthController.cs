using System.IdentityModel.Tokens.Jwt;
using HelpPoint.Api.Config;
using HelpPoint.Contracts;
using HelpPoint.Infrastructure.Database.Models;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;
    public AuthController(
        UserManager<ApplicationUser> userManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
    [Authorize(Roles = AppConstants.Roles.AdminNormalized)]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            var user = new ApplicationUser { UserName = dto.UserName, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var rolesResult = await _userManager.AddToRoleAsync(user, "SupportStaff");
            return rolesResult.Succeeded
                ? Ok(new
                {
                    user.UserName,
                    user.Email
                })
                : BadRequest(rolesResult.Errors);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password)) return Unauthorized();
        var roles = (await _userManager.GetRolesAsync(user)).ToList();
        var token = _tokenService.CreateToken(user, roles);
        var refreshToken = _tokenService.CreateToken(user, roles,true);

        return Ok(new LoginResponse
        {
            UserName     = user.UserName!,
            Email        = user.Email!,
            Token        = token,
            RefreshToken = refreshToken
        });
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        try
        {
            var principal = _tokenService.ValidateRefreshToken(request.RefreshToken);
            if (principal == null)
            {
                return Unauthorized("Invalid refresh token");
            }

            var expirationClaim = principal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
            if (expirationClaim == null)
            {
                return Unauthorized("Invalid refresh token structure.");
            }

            var expirationDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expirationClaim)).UtcDateTime;
            if (expirationDate < DateTime.UtcNow)
            {
                return Unauthorized("Refresh token has expired. Please log in again.");
            }

            var userName = principal.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("Invalid refresh token.");
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var roles           = (await _userManager.GetRolesAsync(user)).ToList();
            var newAccessToken  = _tokenService.CreateToken(user, roles);
            var newRefreshToken = _tokenService.CreateToken(user, roles, true);

            return Ok(new LoginResponse
            {
                UserName     = user.UserName!,
                Email        = user.Email!,
                Token        = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

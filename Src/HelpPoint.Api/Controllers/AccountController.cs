using HelpPoint.Contracts;
using HelpPoint.Infrastructure.Database.Models;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;
    public AccountController(
        UserManager<ApplicationUser> userManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
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
                    user.Email,
                    Token = _tokenService.CreateToken(user)
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
        var token = _tokenService.CreateToken(user);
        return Ok(new
        {
            user.UserName,
            user.Email,
            Token = token
        });
    }
}

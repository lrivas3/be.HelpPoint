using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Features.Users;

[ApiController]
[Route("api/v1/user")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] RegisterDto request)
    {
        var response = await userService.CreateUser(request);
        return Ok(response);
    }
}

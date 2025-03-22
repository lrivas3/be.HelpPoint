using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Features.Support;

[ApiController]
[Route("api/v{version:apiVersion}/support")]
[ApiVersion("1.0")]
public class SupportController : ControllerBase
{
    [HttpGet]
    public IActionResult GetV1() => Ok(new { message = "This is version 1.0" });
}

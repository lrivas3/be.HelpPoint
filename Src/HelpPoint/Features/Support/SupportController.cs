using Asp.Versioning;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Features.Support;

[ApiController]
[Route("api/v{version:apiVersion}/support")]
[ApiVersion("1.0")]
public class SupportController(ISupport support) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SupportRequestResponse>> CreateSupportRequest([FromBody] SupportRequestRequest supportRequest)
    {
        var response     = await support.CreateSupportRequestAsync(supportRequest);
        return Ok(response);
    }
}

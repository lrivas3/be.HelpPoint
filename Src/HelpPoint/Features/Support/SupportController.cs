using Asp.Versioning;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;
using HelpPoint.Infrastructure.Models.Support;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Features.Support;

[ApiController]
[Route("api/v{version:apiVersion}/supports")]
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

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SupportRequestResponse>>
        GetSupportRequest(Guid id)
    {
        var response = await support.GetSupportRequestAsync(id);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<SupportRequestResponse>>>
        ListSupportRequests()
    {
        var response = await support.ListSupportRequestsAsync();
        return Ok(response);
    }
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<SupportRequestResponse>>>
        UpdateSupportRequests([FromBody]SupportRequestUpdateRequest request, Guid id)
    {
        var response = await support.UpdateSupportRequestAsync(request, id);
        return Ok(response);
    }
}

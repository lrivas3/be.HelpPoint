using Asp.Versioning;
using HelpPoint.Infrastructure.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Features.Tickets;

[ApiController]
[Route("api/v{version:apiVersion}/tickets")]
[ApiVersion("1.0")]
public class TicketController(ITicket ticket) : ControllerBase
{
    [HttpPost]
    // [Authorize]
    public async Task<IActionResult> CreateTicket([FromBody] TicketRequest request)
    {
        var result = await ticket.CreateTicket(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetTickets()
    {
        var result = await ticket.ListTicketsForKanban();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTicket(Guid id)
    {
        var result = await ticket.GetTicket(id);
        return Ok(result);
    }
    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteTicket(Guid id) => throw new NotImplementedException();

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTicket(Guid id, [FromBody] TicketUpdateRequest request)
    {
        var updated = await ticket.UpdateTicket(id, request);
        return Ok(updated);
    }
    [HttpPost("{id:guid}/comments")]
    public Task<IActionResult> AddTicketComment([FromBody] TicketCommentRequest request, Guid id) => throw new NotImplementedException();
}

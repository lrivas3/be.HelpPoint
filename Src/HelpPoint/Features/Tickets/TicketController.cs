using Asp.Versioning;
using HelpPoint.Infrastructure.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Features.Tickets;

[ApiController]
[Route("api/v{version:apiVersion}/tickets")]
[ApiVersion("1.0")]
public class TicketController(ITicket ticket) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] TicketRequest request)
    {
        var result = await ticket.CreateTicket(request);
        return Ok(result);
    }

    [HttpGet]
    public Task<IActionResult> GetTickets() => throw new NotImplementedException();
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTicket(Guid id)
    {
        var result = await ticket.GetTicket(id);
        return Ok(result);
    }
    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteTicket(Guid id) => throw new NotImplementedException();
    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateTicket([FromBody] TicketUpdateRequest updateRequest,Guid id) => throw new NotImplementedException();
    [HttpPost("{id:guid}/comments")]
    public Task<IActionResult> AddTicketComment([FromBody] TicketCommentRequest request, Guid id) => throw new NotImplementedException();
}

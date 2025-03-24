using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;
using HelpPoint.Infrastructure.Models.Ticket;

namespace HelpPoint.Features.Tickets;

public interface ITicket
{
    public Task<TicketResponse> CreateTicket(TicketRequest request);
    public Task<TicketResponse> GetTicket(Guid id);
    public Task<List<TicketResponse?>> ListTicket(Guid id);
    public Task<TicketResponse> UpdateTicket(TicketUpdateRequest request);
}

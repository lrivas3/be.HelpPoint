using AutoMapper;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;
using HelpPoint.Infrastructure.Models.Ticket;

namespace HelpPoint.Features.Tickets;

public class TicketService(IMapper mapper, ITicketRepository repository) : ITicket
{
    public async Task<TicketResponse> CreateTicket(TicketRequest request)
    {
        var nuevoTicket = mapper.Map<Ticket>(request);
        await repository.AddAsync(nuevoTicket);
        var response = mapper.Map<TicketResponse>(nuevoTicket);
        return response;
    }

    public Task<TicketResponse> GetTicket(Guid id) => throw new NotImplementedException();

    public Task<List<TicketResponse?>> ListTicket(Guid id) => throw new NotImplementedException();

    public Task<TicketResponse> UpdateTicket(TicketUpdateRequest request) => throw new NotImplementedException();
}

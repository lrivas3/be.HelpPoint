using AutoMapper;
using HelpPoint.Common.Errors.Exceptions;
using HelpPoint.Features.Auth;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;
using HelpPoint.Infrastructure.Models.Ticket;

namespace HelpPoint.Features.Tickets;

public class TicketService(IMapper mapper, ITicketRepository repository) : ITicket
{
    public async Task<TicketResponse> CreateTicket(TicketRequest request)
    {
        // var userCode        = currentUserAccessor.GetCurrentUserId();
        // var usuarioCreacion = repository.GetCreationUser()
        var nuevoTicket = new Ticket
        {
            Id = Guid.CreateVersion7(),
            OrdenEnTablero = request.OrdenEnTablero,
            Titulo = request.Titulo,
            Descripcion = request.Descripcion,
            EstadoId = request.EstadoId,
            TipoId = request.TipoId ?? 1,
            PrioridadId = request.PrioridadId,
            FechaCreacion = DateTime.Now.ToUniversalTime(),
            FechaCierre = null,
            SupportRequestId = request.SupportRequestId,
            CreatedByUserId = request.CreatedByUserId,
        };
        await repository.AddAsync(nuevoTicket);
        var response = mapper.Map<TicketResponse>(nuevoTicket);
        return response;
    }

    public async Task<TicketResponse> GetTicket(Guid id)
    {
        var ticketExistente = await repository.GetByIdAsync(id) ??
                              throw new NotFoundException("No se encontró el ticket");

        var estado = await repository.GetEstado(ticketExistente.EstadoId) ??
                     throw new NotFoundException("No se encontró el estado del ticket");

        var tipo = await repository.GetTipo(ticketExistente.TipoId) ??
                   throw new NotFoundException("No se encontró el tipo del ticket");

        var prioridad = await repository.GetPrioridad(ticketExistente.PrioridadId) ??
                        throw new NotFoundException("No se encontró la prioridad del ticket");

        var createdByUser = await repository.GetCreationUser(ticketExistente.CreatedByUserId) ??
                            throw new NotFoundException("No se encontró el usuario creador del ticket");

        var ticketResponse = new TicketResponse
        {
            Id = ticketExistente.Id,
            OrdenEnTablero = ticketExistente.OrdenEnTablero,
            Titulo = ticketExistente.Titulo,
            Descripcion = ticketExistente.Descripcion,
            Estado = estado,
            Tipo = tipo,
            Prioridad = prioridad,
            FechaCreacion = ticketExistente.FechaCreacion,
            FechaCierre = ticketExistente.FechaCierre,
            SupportRequestId = ticketExistente.SupportRequestId,
            CreatedBy = createdByUser
        };

        return ticketResponse;
    }

    public Task<List<TicketResponse?>> ListTicket(Guid id) => throw new NotImplementedException();

    public Task<TicketResponse> UpdateTicket(TicketUpdateRequest request) => throw new NotImplementedException();
}

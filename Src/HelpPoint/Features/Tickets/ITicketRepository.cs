using HelpPoint.Common;
using HelpPoint.Infrastructure.Dtos.Response;
using HelpPoint.Infrastructure.Models.Ticket;

namespace HelpPoint.Features.Tickets;

public interface ITicketRepository : IRepository<Ticket>
{
    public Task<LookUpResponse?> GetEstado(int id);
    public Task<LookUpResponse?> GetTipo(int id);
    public Task<LookUpResponse?> GetPrioridad(int id);
    public Task<UserLookUpResponse?> GetCreationUser(Guid id);
};

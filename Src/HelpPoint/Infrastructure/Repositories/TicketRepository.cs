using HelpPoint.Features.Tickets;
using HelpPoint.Infrastructure.DataBase;
using HelpPoint.Infrastructure.Dtos.Response;
using HelpPoint.Infrastructure.Models.Ticket;
using Microsoft.EntityFrameworkCore;

namespace HelpPoint.Infrastructure.Repositories;

public class TicketRepository(HelpPointDbContext context) : Repository<Ticket>(context), ITicketRepository
{
    public async Task<LookUpResponse?> GetEstado(int id) =>
        await context.TicketEstados.Where(x => x.Id == id)
            .Select(x => new LookUpResponse
            {
                Id = x.Id,
                Nombre = x.NombreEstado,
            })
            .FirstOrDefaultAsync();

    public async Task<LookUpResponse?> GetTipo(int id) =>
        await context.Tipos.Where(x => x.Id == id)
            .Select(x => new LookUpResponse
            {
                Id = x.Id,
                Nombre = x.Nombre,
            })
            .FirstOrDefaultAsync();

    public async Task<LookUpResponse?> GetPrioridad(int id) =>
        await context.Prioridades.Where(x => x.Id == id)
            .Select(x => new LookUpResponse
            {
                Id = x.Id,
                Nombre = x.Nombre,
            })
            .FirstOrDefaultAsync();

    public async Task<UserLookUpResponse?> GetCreationUser(Guid id) =>
        await context.Users.Where(x => x.Id == id)
            .Select(x => new UserLookUpResponse
            {
                CreatedByUserId = x.Id,
                CreatedByUserName = x.Name
            })
            .FirstOrDefaultAsync();
}

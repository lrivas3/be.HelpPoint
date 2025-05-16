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

    public async Task<List<KanbanTicketResponse>?> ListTickets() => await context.Tickets.Select(x => new KanbanTicketResponse
    {
        Id = x.Id.ToString(),
        Title = x.Titulo,
        Description = x.Descripcion,
        Estado = new LookUpResponse { Id = x.EstadoId, Nombre = x.Estado.NombreEstado },
        Tipo = new LookUpResponse { Id = x.TipoId, Nombre = x.Tipo.Nombre },
        Prioridad = new LookUpResponse { Id = x.PrioridadId, Nombre = x.Prioridad.Nombre },
        CreationDate = x.FechaCreacion,
        ClosureDate = x.FechaCierre,
        OrderInBoard = x.OrdenEnTablero ?? 0,
        Tags = context.TicketTags.Where(j => j.TicketId == x.Id)
            .Select(tt => tt.Tag.Nombre)
            .ToList(),
        Progress = null,
        Checklist = null,
        Attachments = null,
        Avatars = new List<string>()
    }).ToListAsync();
}

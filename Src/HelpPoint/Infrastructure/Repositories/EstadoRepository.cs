using HelpPoint.Features.Catalogo;
using HelpPoint.Infrastructure.DataBase;
using HelpPoint.Infrastructure.Models.Ticket;
using Microsoft.EntityFrameworkCore;

namespace HelpPoint.Infrastructure.Repositories;

public class EstadoRepository(HelpPointDbContext context) : Repository<Estado>(context), IEstadoRepository
{
    public async Task<List<Estado>> GetAllEstadosAsync()
    {
        return await context.TicketEstados.ToListAsync();
    }
}
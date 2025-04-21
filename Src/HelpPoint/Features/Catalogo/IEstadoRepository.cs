using HelpPoint.Common;
using HelpPoint.Infrastructure.Models.Ticket;

namespace HelpPoint.Infrastructure.Repositories;

public interface IEstadoRepository : IRepository<Estado>
{
    public Task<List<Estado>> GetAllEstadosAsync();
} 
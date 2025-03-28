using HelpPoint.Features.Tickets;
using HelpPoint.Infrastructure.DataBase;
using HelpPoint.Infrastructure.Models.Ticket;

namespace HelpPoint.Infrastructure.Repositories;

public class TicketRepository(HelpPointDbContext context) : Repository<Ticket>(context), ITicketRepository;

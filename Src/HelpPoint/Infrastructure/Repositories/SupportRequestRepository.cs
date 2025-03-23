using HelpPoint.Features.Support;
using HelpPoint.Infrastructure.DataBase;
using HelpPoint.Infrastructure.Models.Support;

namespace HelpPoint.Infrastructure.Repositories;

public class SupportRequestRepository(HelpPointDbContext context) : Repository<SupportRequest>(context),ISupportRequestRepository
{
    public async Task<SupportRequest?> CreateSupportRequestAsync(SupportRequest supportRequest)
    {
        var entry = await context.SupportRequests.AddAsync(supportRequest);
        _ = await context.SaveChangesAsync();
        return entry.Entity;
    }
    public Task<bool> DeleteSupportRequestAsync(int id) => throw new NotImplementedException();
}

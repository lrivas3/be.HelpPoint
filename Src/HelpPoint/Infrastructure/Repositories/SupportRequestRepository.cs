using HelpPoint.Features.Support;
using HelpPoint.Infrastructure.DataBase;
using HelpPoint.Infrastructure.Models.Support;

namespace HelpPoint.Infrastructure.Repositories;

public class SupportRequestRepository(HelpPointDbContext context) : ISupportRequestRepository
{
    public Task<SupportRequest?> GetSupportRequestByIdAsync(int id) => throw new NotImplementedException();

    public async Task<SupportRequest?> CreateSupportRequestAsync(SupportRequest supportRequest)
    {
        var entry = await context.SupportRequests.AddAsync(supportRequest);
        _ = await context.SaveChangesAsync();
        return entry.Entity;
    }

    public Task<SupportRequest?> UpdateSupportRequestAsync(SupportRequest supportRequest) => throw new NotImplementedException();

    public Task<bool> DeleteSupportRequestAsync(int id) => throw new NotImplementedException();
}

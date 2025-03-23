using HelpPoint.Common;
using HelpPoint.Infrastructure.Models.Support;

namespace HelpPoint.Features.Support;

public interface ISupportRequestRepository : IRepository<SupportRequest>
{
    public Task<SupportRequest?> CreateSupportRequestAsync(SupportRequest supportRequest);
    public Task<SupportRequest?> UpdateSupportRequestAsync(SupportRequest supportRequest);
    public Task<bool> DeleteSupportRequestAsync(int id);
}

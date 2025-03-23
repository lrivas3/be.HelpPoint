using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;

namespace HelpPoint.Features.Support;

public interface ISupport
{
    public Task<SupportRequestResponse> CreateSupportRequestAsync(SupportRequestRequest request);
    public Task<SupportRequestResponse> UpdateSupportRequestAsync(SupportRequestRequest request);
    public Task<SupportRequestResponse> GetSupportRequestAsync(Guid requestId);
    public Task<SupportRequestResponse> DeleteSupportRequestAsync(Guid requestId);
}

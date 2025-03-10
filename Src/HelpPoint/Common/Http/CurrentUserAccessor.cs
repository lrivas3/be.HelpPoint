using System.Security.Claims;
using HelpPoint.Common.Errors.Exceptions;
using HelpPoint.Features.Auth;

namespace HelpPoint.Common.Http;

public class CurrentUserAccessor(IHttpContextAccessor httpContextAccessor) : ICurrentUserAccessor
{
    public string GetCurrentUsername() =>
        httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)
            ?.Value ?? throw new UnauthorizedException("token invalido");

    public string GetCurrentRole() =>
        httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ??
        throw new UnauthorizedException("token invalido");
}

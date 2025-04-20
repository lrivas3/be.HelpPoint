using System.Security.Claims;
using HelpPoint.Common.Errors.Exceptions;
using HelpPoint.Features.Auth;
using Microsoft.IdentityModel.JsonWebTokens;

namespace HelpPoint.Common.Http;

public class CurrentUserAccessor(IHttpContextAccessor httpContextAccessor) : ICurrentUserAccessor
{
    public string GetCurrentUsername() =>
        httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)
            ?.Value ?? throw new UnauthorizedException("token invalido");

    public string GetCurrentUserId() =>
        httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
        ?? throw new UnauthorizedException("Token inválido");

    public string GetCurrentUserSub() =>
        httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
        ?? throw new UnauthorizedException("Token inválido");

    public string GetCurrentRole() =>
        httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ??
        throw new UnauthorizedException("token invalido");
}

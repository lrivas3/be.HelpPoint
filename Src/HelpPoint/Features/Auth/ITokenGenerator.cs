using System.Security.Claims;

namespace HelpPoint.Features.Auth;

public interface ITokenGenerator
{
    public string GenerateToken(string userName, List<string?> roles, bool isRefreshToken = false);
    public ClaimsPrincipal? ValidateToken(string token);
}

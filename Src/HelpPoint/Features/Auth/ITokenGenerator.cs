using System.Security.Claims;

namespace HelpPoint.Features.Auth;

public interface ITokenGenerator
{
    public string GenerateToken(Guid userId, string userName, IEnumerable<string> roles, bool isRefresh = false);
    public ClaimsPrincipal? ValidateToken(string token);
}

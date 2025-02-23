using System.Security.Claims;
using HelpPoint.Infrastructure.Database.Models;
using HelpPoint.Infrastructure.Dtos;

namespace HelpPoint.Contracts;

public interface ITokenService
{
    string           CreateToken(ApplicationUser user, List<string> userRoles, bool refresh = false);
    ClaimsPrincipal? ValidateRefreshToken(string token);
}

using HelpPoint.Infrastructure.Database.Models;

namespace HelpPoint.Contracts;

public interface ITokenService
{
    string CreateToken(ApplicationUser user);
}

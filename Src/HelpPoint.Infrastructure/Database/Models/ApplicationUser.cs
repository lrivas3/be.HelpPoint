using Microsoft.AspNetCore.Identity;

namespace HelpPoint.Infrastructure.Database.Models;

public class ApplicationUser : IdentityUser
{
    public string Token { get; set; } = string.Empty;
    public DateTime TokenCreatedAt { get; set; }
    public DateTime TokenExpireddAt { get; set; }
}

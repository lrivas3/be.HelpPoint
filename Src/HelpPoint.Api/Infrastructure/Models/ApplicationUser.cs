using Microsoft.AspNetCore.Identity;

namespace HelpPoint.Infrastructure.Database.Models;

public class ApplicationUser : IdentityUser
{
    public string? ManagerId { get; set; }
}

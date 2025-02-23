using HelpPoint.Api.Config;
using HelpPoint.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpPoint.Api.Data;

public class DataContext : IdentityDbContext<ApplicationUser>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Identity");
        base.OnModelCreating(modelBuilder);

        List<IdentityRole> roles =
        [
            new() { Id = "1", Name = AppConstants.Roles.Admin, NormalizedName = AppConstants.Roles.AdminNormalized },
            new() { Id = "2", Name = AppConstants.Roles.AreaManager, NormalizedName        = AppConstants.Roles.AreaManagerNormalized },
            new() { Id = "3", Name = AppConstants.Roles.SupportStaff, NormalizedName       = AppConstants.Roles.SupportStaffNormalized }
        ];

        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}

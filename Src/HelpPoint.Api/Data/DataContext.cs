using HelpPoint.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Constants = HelpPoint.Api.Config.Constants;

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
            new() { Id = "1", Name = Constants.Admin.Name, NormalizedName = Constants.Admin.Normalizedname },
            new() { Id = "2", Name = Constants.AreaManager.Name, NormalizedName        = Constants.AreaManager.Normalizedname },
            new() { Id = "3", Name = Constants.SupportStaff.Name, NormalizedName       = Constants.SupportStaff.Normalizedname }
        ];

        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}

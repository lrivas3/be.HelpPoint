using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SupportHub.Api.Data;

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
                new() { Name = "Admin", NormalizedName = "ADMIN" },
                new() { Name = "AreaManager", NormalizedName = "AREAMANAGER" },
                new() { Name = "SupportStaff", NormalizedName = "SUPPORTSTAFF" }
            ];
            
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
}
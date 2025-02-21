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
        }
}
using HelpPoint.Config;
using HelpPoint.Infrastructure.Database.Models;
using HelpPoint.Infrastructure.Database.Models.Support;
using HelpPoint.Infrastructure.Database.Models.Ticket;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpPoint.Data;

public class DataContext : IdentityDbContext<ApplicationUser>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Unidad> Unidades { get; set; } = null!;
    public DbSet<Empleado> Empleados { get; set; } = null!;
    public DbSet<EstadoSolicitud> EstadoSolicitudes { get; set; } = null!;
    public DbSet<SupportRequest> SupportRequests { get; set; } = null!;
    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<RoleMenu> RolesMenus { get; set; } = null!;
    public DbSet<TicketEstado> TicketEstados { get; set; } = null!;
    public DbSet<TicketPrioridad> TicketPrioridades { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<TicketAsignacion> TicketAsignaciones { get; set; } = null!;
    public DbSet<TicketHistorial> TicketHistorial { get; set; } = null!;
    public DbSet<TicketComentario> TicketComentarios { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<TicketTag> TicketTags { get; set; } = null!;
    public DbSet<Notificacion> Notifications { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Identity");
        base.OnModelCreating(modelBuilder);

        // Identity roles
        List<IdentityRole> roles =
        [
            new() { Id = "1", Name = AppConstants.Roles.Admin, NormalizedName = AppConstants.Roles.AdminNormalized },
            new() { Id = "2", Name = AppConstants.Roles.AreaManager, NormalizedName = AppConstants.Roles.AreaManagerNormalized },
            new() { Id = "3", Name = AppConstants.Roles.SupportStaff, NormalizedName = AppConstants.Roles.SupportStaffNormalized }
        ];
        modelBuilder.Entity<IdentityRole>().HasData(roles);

        // Relaciones para Unidades y Empleados
        modelBuilder.Entity<Empleado>()
            .HasOne(e => e.Unidad)
            .WithMany()
            .HasForeignKey(e => e.UnidadId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relaciones para Support Requests
        modelBuilder.Entity<SupportRequest>()
            .HasOne(s => s.Estado)
            .WithMany()
            .HasForeignKey(s => s.EstadoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SupportRequest>()
            .HasOne(s => s.Empleado)
            .WithMany()
            .HasForeignKey(s => s.EmpleadoId)
            .OnDelete(DeleteBehavior.SetNull);

        // Relaciones para Tickets
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Estado)
            .WithMany()
            .HasForeignKey(t => t.EstadoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Prioridad)
            .WithMany()
            .HasForeignKey(t => t.PrioridadId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.SupportRequest)
            .WithMany()
            .HasForeignKey(t => t.SupportRequestId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TicketAsignacion>()
            .HasOne(a => a.Ticket)
            .WithMany()
            .HasForeignKey(a => a.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TicketHistorial>()
            .HasOne(h => h.Ticket)
            .WithMany()
            .HasForeignKey(h => h.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TicketComentario>()
            .HasOne(c => c.Ticket)
            .WithMany()
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TicketTag>()
            .HasOne(tt => tt.Ticket)
            .WithMany()
            .HasForeignKey(tt => tt.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TicketTag>()
            .HasOne(tt => tt.Tag)
            .WithMany()
            .HasForeignKey(tt => tt.TagId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Notificacion>()
            .HasOne(n => n.Ticket)
            .WithMany()
            .HasForeignKey(n => n.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relaciones para Menús y Roles
        modelBuilder.Entity<Menu>()
            .HasOne(m => m.Parent)
            .WithMany(m => m.SubMenus)
            .HasForeignKey(m => m.ParentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RoleMenu>()
            .HasKey(rm => new { rm.RoleId, rm.MenuId });

        modelBuilder.Entity<RoleMenu>()
            .HasOne(rm => rm.Menu)
            .WithMany()
            .HasForeignKey(rm => rm.MenuId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

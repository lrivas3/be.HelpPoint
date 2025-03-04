using HelpPoint.Config;
using HelpPoint.Infrastructure.Models.Support;
using HelpPoint.Infrastructure.Models.Ticket;
using HelpPoint.Infrastructure.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace HelpPoint.Data;

public class HelpPointDbContext(DbContextOptions<HelpPointDbContext> options) : DbContext(options)
{
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
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Roles> Roles { get; set; } = null!;
    public DbSet<UserRoles> UserRoles { get; set; } = null!;
    public DbSet<RoleClaims> RoleClaims { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Identity roles
        List<Roles> roles =
        [
            new() { Id = Guid.Parse("01956042-3344-70a8-99d7-7a337595c1ea"), Name = AppConstants.Roles.Admin, NormalizedName = AppConstants.Roles.AdminNormalized },
            new() { Id = Guid.Parse("01956042-3344-7953-b575-59d8f088a283"), Name = AppConstants.Roles.AreaManager, NormalizedName = AppConstants.Roles.AreaManagerNormalized },
            new() { Id = Guid.Parse("01956042-3344-7a85-8117-020290a145f9"), Name = AppConstants.Roles.SupportStaff, NormalizedName = AppConstants.Roles.SupportStaffNormalized }
        ];
        modelBuilder.Entity<Roles>().HasData(roles);

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
            .HasForeignKey(t => t.CodigoEstado)
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

        // Relaciones entre Usuarios y Roles
        modelBuilder.Entity<UserRoles>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRoles>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserRoles>()
            .HasOne<Roles>()
            .WithMany()
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relaciones para RoleClaims
        modelBuilder.Entity<RoleClaims>()
            .HasOne<Roles>()
            .WithMany()
            .HasForeignKey(rc => rc.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

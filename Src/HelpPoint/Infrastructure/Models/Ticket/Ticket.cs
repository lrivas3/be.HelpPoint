using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HelpPoint.Infrastructure.Database.Models.Support;
using HelpPoint.Infrastructure.Database.Models.Ticket;

namespace HelpPoint.Infrastructure.Models.Ticket;

[Table("Tickets", Schema = "Ticket")]
public class Ticket
{
    [Key]
    [MaxLength(36)]
    public string Id { get; set; } = string.Empty;

    public int? OrdenEnTablero { get; set; }

    [Required]
    [MaxLength(255)]
    public string Titulo { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    [Required]
    [MaxLength(36)]
    public string EstadoId { get; set; } = string.Empty;

    [Required]
    [MaxLength(36)]
    public string PrioridadId { get; set; } = string.Empty;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public DateTime? FechaCierre { get; set; }

    [MaxLength(36)]
    public string? SupportRequestId { get; set; }

    [Required]
    [MaxLength(36)]
    public string CreatedByUserId { get; set; } = string.Empty;

    [ForeignKey("EstadoId")]
    public TicketEstado Estado { get; set; } = null!;

    [ForeignKey("PrioridadId")]
    public TicketPrioridad Prioridad { get; set; } = null!;

    [ForeignKey("SupportRequestId")]
    public SupportRequest? SupportRequest { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HelpPoint.Infrastructure.Models.Support;

namespace HelpPoint.Infrastructure.Models.Ticket;

[Table("Tickets", Schema = "Ticket")]
public class Ticket
{
    [Key]
    public Guid Id { get; set; }

    public int? OrdenEnTablero { get; set; }

    [Required]
    [MaxLength(255)]
    public string Titulo { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    [Required]
    public string CodigoEstado { get; set; } = string.Empty;

    [Required]
    public Guid PrioridadId { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public DateTime? FechaCierre { get; set; }

    public Guid? SupportRequestId { get; set; }

    [Required]
    [MaxLength(36)]
    public Guid CreatedByUserId { get; set; }

    [ForeignKey("EstadoId")]
    public TicketEstado Estado { get; set; } = null!;

    [ForeignKey("PrioridadId")]
    public TicketPrioridad Prioridad { get; set; } = null!;

    [ForeignKey("SupportRequestId")]
    public SupportRequest? SupportRequest { get; set; }
}

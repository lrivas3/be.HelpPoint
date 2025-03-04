using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Models.Ticket;

[Table("TicketHistorial", Schema = "Ticket")]
public class TicketHistorial
{
    [Key]
    [MaxLength(36)]
    public string Id { get; set; } = string.Empty;

    [Required]
    [MaxLength(36)]
    public string TicketId { get; set; } = string.Empty;

    [Required]
    public DateTime FechaCambio { get; set; } = DateTime.UtcNow;

    public string? CampoModificado { get; set; }

    public string? ValorAnterior { get; set; }

    public string? ValorNuevo { get; set; }

    [MaxLength(36)]
    public string? ChangedByUserId { get; set; }

    [ForeignKey("TicketId")]
    public Infrastructure.Models.Ticket.Ticket Ticket { get; set; } = null!;
}

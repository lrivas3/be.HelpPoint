using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Database.Models.Ticket;
[Table("TicketAsignaciones", Schema = "Ticket")]
public class TicketAsignacion
{
    [Key]
    [MaxLength(36)]
    public string Id { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(36)]
    public string TicketId { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(36)]
    public string UserId { get; set; } = string.Empty;
    
    [Required]
    public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;
    
    public DateTime? FechaFin { get; set; }
    
    [Required]
    public int TiempoEmpleadoMinutos { get; set; } = 0;
    
    [ForeignKey("TicketId")]
    public Infrastructure.Models.Ticket.Ticket Ticket { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Database.Models.Ticket;
[Table("TicketComentarios", Schema = "Ticket")]
public class TicketComentario
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
    public string Comentario { get; set; } = string.Empty;
    
    [Required]
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    
    [ForeignKey("TicketId")]
    public Ticket Ticket { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Database.Models.Ticket;

[Table("TicketEstados", Schema = "Ticket")]
public class TicketEstado
{
    [Key]
    [MaxLength(36)]
    public string Codigo { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string Descripcion { get; set; } = string.Empty;
}

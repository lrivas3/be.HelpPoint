using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Database.Models.Ticket;

[Table("Notificaciones", Schema = "Ticket")]
public class Notificacion
{
    [Key] [MaxLength(36)] public string Id { get; set; } = string.Empty;

    [MaxLength(36)] public string? TicketId { get; set; }

    [MaxLength(36)] public string? UserId { get; set; }

    [Required] [MaxLength(50)] public string TipoNotificacion { get; set; } = string.Empty;

    [Required] public DateTime FechaEnvio { get; set; } = DateTime.UtcNow;

    [Required] public bool ExitoEnvio { get; set; } = false;

    public string? Mensaje { get; set; }

    [ForeignKey("TicketId")] public Ticket? Ticket { get; set; }

    [ForeignKey("UserId")] public ApplicationUser? User { get; set; }
}
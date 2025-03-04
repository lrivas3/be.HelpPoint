﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Models.Ticket;
[Table("TicketComentarios", Schema = "Ticket")]
public class TicketComentario
{
    [Key]
    [MaxLength(36)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(36)]
    public Guid TicketId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public string Comentario { get; set; } = string.Empty;

    [Required]
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    [ForeignKey("TicketId")]
    public Ticket Ticket { get; set; } = null!;
}

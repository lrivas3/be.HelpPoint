using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HelpPoint.Infrastructure.Database.Models.Ticket;
using Microsoft.EntityFrameworkCore;

namespace HelpPoint.Infrastructure.Models.Ticket;

[Table("TicketTags", Schema = "Ticket")]
[PrimaryKey(nameof(TicketId), nameof(TagId))]
public class TicketTag
{
    [Key, Column(Order = 0)]
    [MaxLength(36)]
    public string TicketId { get; set; } = string.Empty;

    [Key, Column(Order = 1)]
    [MaxLength(36)]
    public string TagId { get; set; } = string.Empty;

    [ForeignKey("TicketId")]
    public Ticket Ticket { get; set; } = null!;

    [ForeignKey("TagId")]
    public Tag Tag { get; set; } = null!;
}

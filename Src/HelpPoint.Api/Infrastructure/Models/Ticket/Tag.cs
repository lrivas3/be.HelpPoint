using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Database.Models.Ticket;

[Table("Tags", Schema = "Ticket")]
public class Tag
{
    [Key]
    [MaxLength(36)]
    public string Id { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string Nombre { get; set; } = string.Empty;
}

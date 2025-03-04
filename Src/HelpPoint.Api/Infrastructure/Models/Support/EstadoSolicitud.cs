using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Database.Models.Support;
[Table("EstadoSolicitudes", Schema = "Support")]
public class EstadoSolicitud
{
    [Key]
    [MaxLength(36)]
    public string Id { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(10)]
    public string Codigo { get; set; } = string.Empty;
}

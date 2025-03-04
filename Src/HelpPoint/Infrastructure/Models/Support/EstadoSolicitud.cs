using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Models.Support;
[Table("EstadoSolicitudes", Schema = "Support")]
public class EstadoSolicitud
{
    [Key]
    [MaxLength(36)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(10)]
    public string Codigo { get; set; } = string.Empty;
}

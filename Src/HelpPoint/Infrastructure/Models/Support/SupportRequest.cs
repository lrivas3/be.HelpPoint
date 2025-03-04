using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Database.Models.Support;
[Table("SupportRequests", Schema = "Support")]
public class SupportRequest
{
    [Key]
    [MaxLength(36)]
    public string Id { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string Titulo { get; set; } = string.Empty;
    
    [Required]
    public string Descripcion { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(10)]
    public string Prioridad { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string Tipo { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(36)]
    public string EstadoId { get; set; } = string.Empty;
    
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    
    public DateTime? FechaResolucion { get; set; }
    
    [MaxLength(36)]
    public string? EmpleadoId { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    
    public string? TokenVerificacion { get; set; }
    
    [ForeignKey("EstadoId")]
    public EstadoSolicitud Estado { get; set; } = null!;
    
    [ForeignKey("EmpleadoId")]
    public Empleado? Empleado { get; set; }
}

﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Database.Models.Support;

[Table("Empleados", Schema = "Support")]
public class Empleado
{
    [Key]
    [MaxLength(36)]
    public string Id { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string Nombre { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public bool Estado { get; set; }
    
    [Required]
    [MaxLength(36)]
    public string UnidadId { get; set; } = string.Empty;
    
    [ForeignKey("UnidadId")]
    public Unidad Unidad { get; set; } = null!;
}

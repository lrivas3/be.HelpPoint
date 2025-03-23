using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HelpPoint.Infrastructure.Dtos.Request;

public class SupportRequestRequest
{
    public string Descripcion { get; set; } = string.Empty;
    [JsonIgnore]
    public Guid? EmpleadoId { get; set; }
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}

using System.ComponentModel.DataAnnotations;
using HelpPoint.Common.Constants;

namespace HelpPoint.Infrastructure.Dtos.Request;

public class AssignUsersRequest
{
    [Required(ErrorMessage = "Debe asignar al menos un usuario")]
    public List<string> Users { get; set; } = null!;
    [Required(ErrorMessage = "Debe proporcionar el id del ticket")]
    public string TicketId { get; set; } = null!;
}

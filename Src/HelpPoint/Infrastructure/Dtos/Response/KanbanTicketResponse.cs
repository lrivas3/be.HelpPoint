namespace HelpPoint.Infrastructure.Dtos.Response;

public class KanbanTicketResponse
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int StateCode { get; set; }
    public int? TipoId { get; set; }
    public int? PriorityCode { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? ClosureDate { get; set; }
    public int OrderInBoard { get; set; }
    public List<string> Tags { get; set; } = [];
    public int? Progress { get; set; }
    public string? Checklist { get; set; }
    public int? Attachments { get; set; }
    public List<string> Avatars { get; set; } = [];
}

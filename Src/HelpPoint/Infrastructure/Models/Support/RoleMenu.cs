using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpPoint.Infrastructure.Database.Models.Support;

[Table("RoleMenus", Schema = "Support")]
public class RoleMenu
{
    [Key]
    [MaxLength(36)]
    public string RoleId { get; set; } = string.Empty;
    
    [Key]
    [MaxLength(36)]
    public string MenuId { get; set; } = string.Empty;
    
    [ForeignKey("MenuId")]
    public Menu Menu { get; set; } = null!;
}

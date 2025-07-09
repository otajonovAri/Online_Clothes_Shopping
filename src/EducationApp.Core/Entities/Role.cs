using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Role : BaseEntity
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    //(Navigation properties)
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}

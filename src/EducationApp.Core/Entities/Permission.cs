using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Permission : BaseEntity
{
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [StringLength(500, MinimumLength = 5)] public string? Description { get; set; }

    //(Navigation properties) Many-to-many relationship with Role
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}

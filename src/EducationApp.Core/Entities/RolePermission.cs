using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class RolePermission : BaseEntity
{
    //(Parent class) Role
    [Required] public int RoleId { get; set; }
    [Required] public Role Role { get; set; } = null!;

    //(Parent class) Permission
    [Required] public int PermissionId { get; set; }
    [Required] public Permission Permission { get; set; } = null!;
}

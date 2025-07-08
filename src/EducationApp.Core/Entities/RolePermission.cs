using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class RolePermission : BaseEntity
{
    //(Parent class) Role
    public int RoleId { get; set; }
    public Role Role { get; set; }

    //(Parent class) Permission
    public int PermissionId { get; set; }
    public Permission Permission { get; set; }
}

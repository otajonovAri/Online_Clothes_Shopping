using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Role : BaseEntity
{
	public string Name { get; set; }

    //(Navigation properties)
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}

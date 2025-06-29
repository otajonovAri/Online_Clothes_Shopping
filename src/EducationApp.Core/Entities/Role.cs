using EducationApp.Core.Entities;

namespace EducationApp.Application.Entities;

public class Role
{
	public int Id { get; set; }
	public string Name { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}

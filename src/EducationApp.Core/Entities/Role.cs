namespace EducationApp.Core.Entities;

public class Role
{
	public int Id { get; set; }

	public string Name { get; set; }

    public ICollection<RolePermission> RolePermissions { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}

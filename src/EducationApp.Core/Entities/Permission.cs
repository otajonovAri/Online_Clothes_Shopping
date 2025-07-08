using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Permission : BaseEntity
{
	public string Name { get; set; }
    public string Description { get; set; }

    //(Navigation properties) Many-to-many relationship with Role
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}

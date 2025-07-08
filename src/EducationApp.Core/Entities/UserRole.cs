using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class UserRole : BaseEntity
{
    // Represents the many-to-many relationship between User 
    public int UserId { get; set; }
    public User User { get; set; } = new User();

    // Represents the many-to-many relationship between Role
    public int RoleId { get; set; }
    public Role Role { get; set; } = new Role();
}

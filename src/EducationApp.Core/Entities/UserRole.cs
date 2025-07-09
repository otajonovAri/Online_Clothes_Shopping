using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class UserRole : BaseEntity
{
    // Represents the many-to-many relationship between User 
    [Required] public int UserId { get; set; }
    [Required] public User User { get; set; } = null!;

    // Represents the many-to-many relationship between Role
    [Required] public int RoleId { get; set; }
    [Required] public Role Role { get; set; } = null!;
}

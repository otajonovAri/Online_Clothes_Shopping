using EducationApp.Core.Common;
using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class User : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    public DateTime DateBirth { get; set; } = DateTime.UtcNow;

    public Gender Gender { get; set; }
    public string PasswordHash { get; set; } = null!;
    public string PasswordSolt { get; set; } = null!;
    public string? RefreshToken { get; set; } = null!;

    //(JWt properties)
    /*    public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;*/

    //(Navigation properties) 
    public ICollection<UserRole> UserRoles  { get; set; } = new HashSet<UserRole>();
}

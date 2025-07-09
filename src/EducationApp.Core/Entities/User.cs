using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;
using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class User : BaseEntity
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string? FirstName { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string? LastName { get; set; }

    [Required]
    [MinLength(9)]
    [MaxLength(15)]
    [Phone]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [MaxLength(15)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(10)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateBirth { get; set; } = DateTime.UtcNow;

    public Gender Gender { get; set; }

    //(JWt properties)
    [Required]
    [StringLength(500, MinimumLength = 10)]
    public string PasswordHash { get; set; } = null!;

    [Required]
    [StringLength(500, MinimumLength = 10)]
    public string PasswordSalt { get; set; } = null!;

    [Required]
    [StringLength(500, MinimumLength = 10)]
    public string RefreshToken { get; set; } = null!;

    //(Navigation properties) 
    public ICollection<UserRole> UserRoles  { get; set; } = new HashSet<UserRole>();
}

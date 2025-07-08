using EducationApp.Core.Enums;

namespace EducationApp.Core.DTOs;

public class UserDto
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
    public string RefreshToken { get; set; } = null!;
}
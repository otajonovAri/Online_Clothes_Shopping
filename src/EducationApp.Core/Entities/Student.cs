namespace EducationApp.Core.Entities;

public class Student
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public int GroupId { get; set; }
    public string? Status { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public string? Note { get; set; }
    public string? PasswordHash { get; set; }
    public string PasswordSolt { get; set; } = "";
    public string? RefreshToken { get; set; }
}

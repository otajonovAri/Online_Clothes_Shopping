using EducationApp.Core.Common;
using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class Student : BaseEntity
{
    // Parent class User 
    public int UserId { get; set; }
    public User User { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Status Status { get; set; }
    public Gender Gender { get; set; }
    public DateTime JoinStudentDateTime { get; set; }

    //(Navigation properties) Payment 
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
}

using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class Student
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public Status Status { get; set; }
    public Gender Gender { get; set; }
    public DateTime JoinDate { get; set; }

    public ICollection<Payment> Payments { get; set; } 
    public ICollection<Attendance> Attendances { get; set; }
}

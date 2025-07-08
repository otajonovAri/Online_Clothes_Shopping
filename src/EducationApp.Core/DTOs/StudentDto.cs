using EducationApp.Core.Enums;

namespace EducationApp.Core.DTOs;

public class StudentDto
{
    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public Status Status { get; set; }
    public Gender Gender { get; set; }

    public DateTime JoinDate { get; set; }
}

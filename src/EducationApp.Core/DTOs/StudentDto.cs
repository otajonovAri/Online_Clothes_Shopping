namespace EducationApp.Core.DTOs;

public class StudentDto
{
    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public string Status { get; set; }

    public DateTime JoinDate { get; set; }

    public string Note { get; set; }
}

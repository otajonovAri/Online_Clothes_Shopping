using EducationApp.Core.Enums;

namespace EducationApp.Core.DTOs;

public class StaffDto
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public string Position { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public decimal Salary { get; set; }
}

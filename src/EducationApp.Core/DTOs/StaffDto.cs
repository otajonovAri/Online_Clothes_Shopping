using EducationApp.Core.Enums;

namespace EducationApp.Core.DTOs;

public class StaffDto
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public Position Position { get; set; } = Position.Other;
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateBirth { get; set; }
    public Gender Gender { get; set; }
    public Decimal Salary { get; set; }
    public string StaffImgUrl { get; set; }
}
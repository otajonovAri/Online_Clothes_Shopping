using EducationApp.Core.Common;
using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class Staff : BaseEntity
{
    //(parent Class) User
    public int UserId { get; set; }
    public User User { get; set; }


    public string FullName { get; set; }
    public Position Position { get; set; } = Position.Other;
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateBirth { get; set; }
    public Gender Gender { get; set; }
    public Decimal Salary { get; set; }
    public string StaffImgUrl { get; set; }

    // Navigation properties
    public ICollection<Group> Groups { get; set; } = new HashSet<Group>();
    public ICollection<GroupSubject> GroupSubjects { get; set; } = new HashSet<GroupSubject>();
    public ICollection<StaffSubject> StaffSubjects { get; set; } = new HashSet<StaffSubject>();
}

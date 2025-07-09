using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;
using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class Staff : User
{
    [Required] public Position Position { get; set; } = Position.Other;
    [Required,Range(0 , double.MaxValue)] public Decimal Salary { get; set; }

    // Navigation properties
    public ICollection<Group> Groups { get; set; } = new HashSet<Group>();
    public ICollection<GroupSubject> GroupSubjects { get; set; } = new HashSet<GroupSubject>();
    public ICollection<StaffSubject> StaffSubjects { get; set; } = new HashSet<StaffSubject>();
}

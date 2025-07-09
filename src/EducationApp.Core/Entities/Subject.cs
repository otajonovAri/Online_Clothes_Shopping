using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Subject : BaseEntity
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(500 , MinimumLength = 5)] public string? Description { get; set; }

    // (Navigation properties) 
    public ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();
    public ICollection<GroupSubject> GroupSubjects { get; set; } = new HashSet<GroupSubject>();
    public ICollection<StaffSubject> StaffSubjects { get; set; } = new HashSet<StaffSubject>();
}

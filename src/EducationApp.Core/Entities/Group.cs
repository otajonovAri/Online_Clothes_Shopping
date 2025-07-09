using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Group : BaseEntity
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    // (parent Class) Staff 
    [Required] public int StaffId { get; set; }
    [Required] public Staff Staff { get; set; } = null!;

    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }

    [StringLength(500, MinimumLength = 5)] public string? Description { get; set; }

    // (Navigation properties)
    public ICollection<GroupSubject> GroupSubjects { get; set; } = new HashSet<GroupSubject>();
    public ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();
    public ICollection<ScheduleSlot> ScheduleSlots { get; set; } = new HashSet<ScheduleSlot>();
}

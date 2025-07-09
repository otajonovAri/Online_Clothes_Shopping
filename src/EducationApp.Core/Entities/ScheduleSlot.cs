using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class ScheduleSlot : BaseEntity
{
    [Required,Range(1,30)] public DayOfWeek Day { get; set; }
    [Required] public TimeSpan StartTime { get; set; }
    [Required] public TimeSpan EndTime { get; set; }
    [Required] public int GroupId { get; set; }
    [Required] public Group Group { get; set; } = null!;
}
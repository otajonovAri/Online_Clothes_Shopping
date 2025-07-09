using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class GroupSubject : BaseEntity
{
    // (parent Class) Group
    [Required] public int GroupId { get; set; }
    [Required] public Group Group { get; set; } = null!;

    // (parent Class) Subject
    [Required] public int SubjectId { get; set; }
    [Required] public Subject Subject { get; set; } = null!;

    // (parent Class) Staff
    [Required] public int StaffId { get; set; }
    [Required] public Staff Staff { get; set; } = null!;

    //(parent class) Room
    [Required] public int RoomId { get; set; }
    [Required] public Room Room { get; set; } = null!;

    [Required] public DateTime SessionDate { get; set; }
    [Required] public TimeSpan StartTime { get; set; }
    [Required] public TimeSpan EndTime { get; set; }   
}

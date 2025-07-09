using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using EducationApp.Core.Common;
using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class Attendance : BaseEntity
{
    // (parent class) Student
    [Required] public int StudentId { get; set; }
    [Required] public Student Student { get; set; } = null!;


    //(parent class) Group Subject
    [Required] public int GroupSubjectId { get; set; }
    [Required] public GroupSubject GroupSubject { get; set; } = null!;

    [Required] public DateTime AttendanceDate { get; set; }

    [Required] public bool IsPresent { get; set; }
    public PreparednessLevel? Preparedness { get; set; }
    public ParticipationLevel? Participation { get; set; } 
    [StringLength(500 , MinimumLength = 5)] public string? Note { get; set; } 
}
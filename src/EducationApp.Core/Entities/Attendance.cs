using EducationApp.Core.Common;
using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class Attendance : BaseEntity
{
    // (parent class) Student
    public int StudentId { get; set; }
    public Student Student { get; set; } 

    // (parent class) Group
    public int GroupId { get; set; }
    public Group Group { get; set; } 

    // (parent class) Subject 
    public int SubjectId { get; set; }
    public Subject Subject { get; set; } 

    public DateTime AttendanceDate { get; set; }
    public bool IsPresent { get; set; }
    public PreparednessLevel Preparedness { get; set; } = PreparednessLevel.Average;
    public ParticipationLevel Participation { get; set; } = ParticipationLevel.Passive;
    public string? Note { get; set; } // student's note about the attendance
}
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using EducationApp.Core.Common;
using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class Attendance : BaseEntity
{
    // relationships
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;


    // relationships
    public int GroupSubjectId { get; set; }
    public GroupSubject GroupSubject { get; set; } = null!;
        
    public DateTime AttendanceDate { get; set; }

    public bool IsPresent { get; set; }
    public PreparednessLevel? Preparedness { get; set; }
    public ParticipationLevel? Participation { get; set; } 
    public string? Note { get; set; } 
}
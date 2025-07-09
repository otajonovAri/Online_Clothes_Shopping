using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class StaffSubject : BaseEntity
{
    // (Child Class) Staff
    [Required] public int StaffId { get; set; }
    [Required] public Staff Staff { get; set; } = null!;

    // (Child Class) Subject
    [Required] public int SubjectId { get; set; }
    [Required] public Subject Subject { get; set; } = null!;
}
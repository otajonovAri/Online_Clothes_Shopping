using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class StaffSubject : BaseEntity
{
    // (Child Class) Staff
    public int StaffId { get; set; }
    public Staff Staff { get; set; }

    // (Child Class) Subject
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Subject : BaseEntity
{
   public string SubjectName { get; set; }
   public string SubjectDescription { get; set; }

    // (Navigation properties) 
    public ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();
    public ICollection<GroupSubject> GroupSubjects { get; set; } = new HashSet<GroupSubject>();
}

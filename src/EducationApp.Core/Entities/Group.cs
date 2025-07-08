using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }

    // (parent Class) Staff 
    public int StaffId { get; set; }
    public Staff Staff { get; set; }


    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Schedule { get; set; }
    public string GroupDescription { get; set; }

    // (Navigation properties)
    public ICollection<GroupSubject> GroupSubjects { get; set; } = new HashSet<GroupSubject>();
    public ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();
}

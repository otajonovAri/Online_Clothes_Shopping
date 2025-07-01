namespace EducationApp.Core.Entities;

public class GroupSubject
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int SubjectId { get; set; }
    public int StaffId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Group Group { get; set; }
    public Subject Subjects { get; set; }
    public Staff Staffs { get; set; }
}

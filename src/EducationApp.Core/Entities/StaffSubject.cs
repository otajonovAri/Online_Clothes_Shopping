namespace EducationApp.Core.Entities;

public class StaffSubject
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public int SubjectId { get; set; }

    public Staff Staff { get; set; }
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}   
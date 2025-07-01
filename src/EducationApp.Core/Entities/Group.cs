namespace EducationApp.Core.Entities;

public class Group
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int SubjectId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Subject Subject { get; set; }
    public string?  Schedule { get; set; }

    public ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();
}

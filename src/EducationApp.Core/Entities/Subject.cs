namespace EducationApp.Core.Entities;

public class Subject
{
    public int Id { get; set; }

    public int StaffId { get; set; }
    public Staff Staff { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    public ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();
}

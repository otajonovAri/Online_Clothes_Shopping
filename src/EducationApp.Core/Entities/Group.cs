namespace EducationApp.Core.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
    public string Schedule { get; set; }
    public int StaffId { get; set; }
    public Staff Staff { get; set; }
    public ICollection<GroupSubject> GroupSubjects { get; set; }
    public ICollection<GroupRoom> GroupRooms { get; set; }
}

namespace EducationApp.Core.Entities;

public class Group
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public int RoomId { get; set; }

    public int TeacherId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Schedule { get; set; }
    public Room Room { get; set; }
    public Staff Staff { get; set; }
    public ICollection<GroupRoom> GroupRooms { get; set; } = new List<GroupRoom>();
    public ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();
}

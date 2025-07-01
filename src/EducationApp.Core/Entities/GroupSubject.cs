namespace EducationApp.Core.Entities;

public class GroupSubject
{
    public int GroupId { get; set; }
    public Group Group { get; set; }    

    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; }

    public int StaffId { get; set; }
    public Staff Staff { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}

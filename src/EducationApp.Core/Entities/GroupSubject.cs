using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class GroupSubject : BaseEntity
{
    // (parent Class) Group
    public int GroupId { get; set; }
    public Group Group { get; set; }

    // (parent Class) Subject
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    // (parent Class) Staff
    public int StaffId { get; set; }
    public Staff Staff { get; set; }

    //(parent class) Room
    public int RoomId { get; set; }
    public Room Room { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

namespace EducationApp.Core.Entities;

public class GroupRoom
{
    public int GroupId { get; set; }
    public Group Group { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; }
}
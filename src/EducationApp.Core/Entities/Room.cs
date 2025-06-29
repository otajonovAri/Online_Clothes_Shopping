namespace EducationApp.Core.Entities;

public class Room
{
    public int Id { get; set; }

    public string RoomName { get; set; }

    public int Capacity { get; set; }

    public Type Type { get; set; }
    public ICollection<GroupRoom> GroupRooms { get; set; } = new List<GroupRoom>();
}

using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Room : BaseEntity
{
    public string? RoomName { get; set; }
    public string? RoomNumber { get; set; }  
    public int RoomCapacity { get; set; }
    public int NumberOfDesks { get; set; }
    public int  NumberOfChairs { get; set; }
    public string? RoomDescription { get; set; }

    // (Navigation properties)
    public ICollection<GroupSubject> GroupSubjects { get; set; }

}
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
}

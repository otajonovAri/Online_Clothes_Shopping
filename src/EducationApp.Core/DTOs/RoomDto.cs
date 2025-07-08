namespace EducationApp.Core.DTOs;

public class RoomDto
{
    public int Id { get; set; }
    public string? RoomName { get; set; }
    public string? RoomNumber { get; set; }
    public int RoomCapacity { get; set; }
    public int NumberOfDesks { get; set; }
    public int NumberOfChairs { get; set; }
    public string? RoomDescription { get; set; }
}
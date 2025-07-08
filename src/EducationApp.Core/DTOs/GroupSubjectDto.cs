namespace EducationApp.Core.DTOs;

public class GroupSubjectDto
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int SubjectId { get; set; }
    public int StaffId { get; set; }
    public int RoomId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
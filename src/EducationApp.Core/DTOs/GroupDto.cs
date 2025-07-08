namespace EducationApp.Core.DTOs;

public class GroupDto
{
    public string Name { get; set; }
    public int StaffId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Schedule { get; set; }
    public string GroupDescription { get; set; }
}
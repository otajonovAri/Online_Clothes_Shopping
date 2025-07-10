namespace EducationApp.Core.DTOs;

public class GroupDto
{
    
    public int SubjectId { get; set; }
    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Schedule { get; set; }
}

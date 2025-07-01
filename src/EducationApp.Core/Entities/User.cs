using EducationApp.Application.Entities;
using EducationApp.Core.Enums;
using Role = EducationApp.Application.Entities.Role;

namespace EducationApp.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}

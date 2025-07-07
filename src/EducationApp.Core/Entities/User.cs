using System.Reflection.PortableExecutable;
using EducationApp.Core.Enums;

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
    public string PasswordHasher { get; set; }
    public string PasswordSalt { get; set; }

    public ICollection<Student> Students { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }   
}

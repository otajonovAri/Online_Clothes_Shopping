namespace EducationApp.Core.Entities;

public class Student
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public DateTime JoinDate { get; set; }
    public string Note { get; set; }
    public string PasswordHas { get; set; }
    public string PasswordSold { get; set; }
    public string RefreshToken { get; set; }

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}

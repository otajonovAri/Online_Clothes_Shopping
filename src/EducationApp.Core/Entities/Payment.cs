using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class Payment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } 
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentType PaymentType { get; set; }
    public string PaymentImgUrl { get; set; }
    public string Description { get; set; } 
}

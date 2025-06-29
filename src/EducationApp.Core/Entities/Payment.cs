using EducationApp.Core.Enums;

namespace EducationApp.Core.Entities;

public class Payment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentType PaymentType { get; set; }
    public string Note { get; set; } = "";
}

using EducationApp.Core.Enums;

namespace EducationApp.Core.DTOs;

public class PaymentDto
{
    public int StudentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public PaymentType PaymentType { get; set; }
    public string? PaymentImgUrl { get; set; }
    public string? Description { get; set; }
}
using EducationApp.Core.Common;
using EducationApp.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.Core.Entities;

public class Payment : BaseEntity
{
    // (parent class) Student
    [Required] public int StudentId { get; set; }
    [Required] public Student Student { get; set; } = null!;

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Amount { get; set; }
    [Required] public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    [Required] public PaymentType PaymentType { get; set; }
    [StringLength(200)] public string? PaymentImgUrl { get; set; }
    [StringLength(500, MinimumLength = 5)] public string? Description { get; set; }

    // (Navigation properties)
    public ICollection<PaymentDocument> PaymentDocuments { get; set; } = new HashSet<PaymentDocument>();
}

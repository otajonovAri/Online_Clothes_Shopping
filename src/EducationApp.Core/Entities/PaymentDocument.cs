using EducationApp.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.Core.Entities;

public class PaymentDocument : BaseEntity
{
    [StringLength(200)] public string? FileUrl { get; set; }
    [Required] public int PaymentId { get; set; }
    [Required] public Payment Payment { get; set; } = null!;
}
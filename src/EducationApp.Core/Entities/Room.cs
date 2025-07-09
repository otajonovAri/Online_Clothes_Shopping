using System.ComponentModel.DataAnnotations;
using EducationApp.Core.Common;

namespace EducationApp.Core.Entities;

public class Room : BaseEntity
{
    [Required]
    [MinLength(5)]
    [MaxLength(100)] public string? Number { get; set; }
    [Required,Range(1,100)] public int Capacity { get; set; }
    [StringLength(500 , MinimumLength = 5)] public string? Description { get; set; }

    // (Navigation properties)
    public ICollection<GroupSubject> GroupSubjects { get; set; }
}
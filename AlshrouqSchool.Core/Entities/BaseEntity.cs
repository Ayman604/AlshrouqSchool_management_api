using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlshrouqSchool.Core.Entities;

public abstract class BaseEntity<TKey>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; } = default!;
    [Required]
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }
}

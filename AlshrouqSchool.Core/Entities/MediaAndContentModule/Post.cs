using AlshrouqSchool.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.MediaAndContentModule
{
    public class Post : BaseEntity<int>
    {
        [Required]
        [StringLength(250, MinimumLength = 5)]
        [Display(Name = "العنوان")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        [Display(Name = "الرابط الودود")]
        [RegularExpression(@"^[a-z0-9-]+$", ErrorMessage = "استخدم أحرف صغيرة وأرقام وشرطات فقط")]
        public string Slug { get; set; } = string.Empty;

        [Required]
        [Display(Name = "المحتوى")]
        public string Content { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "الملخص")]
        public string? Excerpt { get; set; }

        [Required]
        [Display(Name = "النوع")]
        public PostType Type { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "ترتيب العرض")]
        public int DisplayOrder { get; set; }

        [Display(Name = "منشور")]
        public bool IsPublished { get; set; }

        [Display(Name = "تاريخ النشر")]
        public DateTime? PublishedAtUtc { get; set; }

        [Display(Name = "محذوف")]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedAtUtc { get; set; } // Soft delete

        // Navigation properties
        public ICollection<PostMedia> Media { get; set; } = new List<PostMedia>();
    }
}

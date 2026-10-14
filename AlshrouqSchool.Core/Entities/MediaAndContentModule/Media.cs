using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Entities.Identity;
using AlshrouqSchool.Domain.Entities.LessonsAndTeachingModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.MediaAndContentModule
{
    public class Media : BaseEntity<int>
    {

        [Required]
        [StringLength(255)]
        [Display(Name = "اسم الملف")]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        [Display(Name = "المسار")]
        public string FilePath { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "نوع MIME")]
        public string MimeType { get; set; } = string.Empty;

        [Required]
        [Range(1, long.MaxValue)]
        [Display(Name = "حجم الملف")]
        public long FileSizeBytes { get; set; }

        [StringLength(500)]
        [Display(Name = "النص البديل")]
        public string? AltText { get; set; }

        [Required]
        [Display(Name = "نوع الوسيط")]
        public MediaType Type { get; set; }

        [Required]
        [Display(Name = "فئة الوسيط")]
        public MediaCategory Category { get; set; }

        [Required]
        [ForeignKey(nameof(UploadedByUser))]
        [Display(Name = "رفع بواسطة")]
        public string UploadedByUserId { get; set; } = string.Empty;

        //[Display(Name = "متاح")]
        //public bool IsActive { get; set; } = true;

        [Display(Name = "محذوف")]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedAtUtc { get; set; } // Soft delete

        #region Navigation properties
        public ApplicationUser? UploadedByUser { get; set; } // ابقى زود ادمن يوزر
        public ICollection<PostMedia> Posts { get; set; } = new List<PostMedia>();
        public ICollection<LessonMedia> Lessons { get; set; } = new List<LessonMedia>();
        #endregion
    }
}

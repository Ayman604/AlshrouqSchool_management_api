using AlshrouqSchool.Core.Entities.Identity;
using AlshrouqSchool.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlshrouqSchool.Core.Entities;

public class Media : BaseEntity
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

public class Post : BaseEntity
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

public class PostMedia : BaseEntity
{
    [Required]
    [ForeignKey(nameof(Post))]
    public int PostId { get; set; }

    [Required]
    [ForeignKey(nameof(Media))]
    public int MediaId { get; set; }

    [Required]
    [Display(Name = "دور الوسيط")]
    public MediaRole MediaRole { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    [Display(Name = "ترتيب العرض")]
    public int DisplayOrder { get; set; }

    // Navigation properties
    public Post Post { get; set; } = null!;
    public Media Media { get; set; } = null!;
}

public class LessonMedia : BaseEntity
{
    [Required]
    [ForeignKey(nameof(Lesson))]
    public int LessonId { get; set; }

    [Required]
    [ForeignKey(nameof(Media))]
    public int MediaId { get; set; }

    [Required]
    [Display(Name = "دور الوسيط")]
    public MediaRole MediaRole { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    [Display(Name = "ترتيب العرض")]
    public int DisplayOrder { get; set; }

    // Navigation properties
    public Lesson Lesson { get; set; } = null!;
    public Media Media { get; set; } = null!;

}

public class AttendanceSession : BaseEntity
{
    [Required]
    [Display(Name = "التاريخ")]
    public DateOnly Date { get; set; }

    [StringLength(500)]
    [Display(Name = "ملاحظات")]
    public string? Notes { get; set; }

    [Required]
    [ForeignKey(nameof(ClassSchedule))]
    public int ClassScheduleId { get; set; }

    // Navigation properties
    public ClassSchedule ClassSchedule { get; set; } = null!;
    public ICollection<AttendanceRecord> Records { get; set; } = new List<AttendanceRecord>();
}

public class AttendanceRecord : BaseEntity
{
    [Required]
    [ForeignKey(nameof(AttendanceSession))]
    public int AttendanceSessionId { get; set; }

    [Required]
    [ForeignKey(nameof(Student))]
    [Display(Name = "الطالب")]
    public int StudentId { get; set; }

    [Required]
    [Display(Name = "الحالة")]
    public AttendanceStatus Status { get; set; }

    [Display(Name = "وقت التسجيل")]
    public DateTime? MarkedAtUtc { get; set; }

    [StringLength(500)]
    [Display(Name = "ملاحظات")]
    public string? Notes { get; set; }

    // Navigation properties
    public AttendanceSession AttendanceSession { get; set; } = null!;
    public Student Student { get; set; } = null!;
}

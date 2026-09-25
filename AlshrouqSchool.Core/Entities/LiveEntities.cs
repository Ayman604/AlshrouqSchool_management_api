using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlshrouqSchool.Core.Entities;

public class LiveSession : BaseEntity
{
    [Required]
    [StringLength(250, MinimumLength = 5)]
    [Display(Name = "عنوان الحصة")]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    [Display(Name = "وصف الحصة")]
    public string? Description { get; set; }

    [Required]
    [Display(Name = "وقت البدء المجدول")]
    public DateTime ScheduledStartAtUtc { get; set; }

    [Display(Name = "وقت البدء الفعلي")]
    public DateTime? StartedAtUtc { get; set; }

    [Display(Name = "وقت الانتهاء الفعلي")]
    public DateTime? EndedAtUtc { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "معرف الغرفة (WebRTC)")]
    public string RoomName { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "رابط التسجيل")]
    [Url(ErrorMessage = "يجب أن يكون رابط صحيح")]
    public string? RecordingUrl { get; set; }

    [Display(Name = "الحالة")]
    public LiveSessionStatus Status { get; set; } = LiveSessionStatus.Scheduled;

    [Display(Name = "التسجيل متاح")]
    public bool RecordingAvailable { get; set; }

    [Display(Name = "تاريخ معالجة التسجيل")]
    public DateTime? RecordingProcessedAtUtc { get; set; }
    #region Foreign Keys

    [Required]
    [ForeignKey(nameof(Lesson))]
    [Display(Name = "الدرس")]
    public int LessonId { get; set; }

    [Required]
    [ForeignKey(nameof(Teacher))]
    [Display(Name = "المعلم")]
    public int TeacherId { get; set; }

    [Required]
    [ForeignKey(nameof(Section))]
    [Display(Name = "الفصل")]
    public int SectionId { get; set; } 
    #endregion


    #region Navigation properties
    public Lesson Lesson { get; set; } = null!;
    public Teacher Teacher { get; set; } = null!;
    public Section Section { get; set; } = null!;
    public ICollection<StudentLiveSessionAttendance> StudentAttendances { get; set; } = new List<StudentLiveSessionAttendance>(); 
    #endregion
}

public class StudentLiveSessionAttendance : BaseEntity
{
    [Required]
    [ForeignKey(nameof(LiveSession))]
    public int LiveSessionId { get; set; }

    [Required]
    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }

    [Required]
    [Display(Name = "وقت الدخول")]
    public DateTime JoinedAtUtc { get; set; }

    [Display(Name = "وقت الخروج")]
    public DateTime? LeftAtUtc { get; set; }

    // Navigation properties
    public LiveSession LiveSession { get; set; } = null!;
    public Student Student { get; set; } = null!;
    
}

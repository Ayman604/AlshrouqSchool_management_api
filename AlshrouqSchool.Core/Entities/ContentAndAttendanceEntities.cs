using AlshrouqSchool.Core.Entities.Identity;

namespace AlshrouqSchool.Core.Entities;

public class Media : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string MimeType { get; set; } = string.Empty;
    public long FileSizeBytes { get; set; }
    public string? AltText { get; set; }
    public MediaType Type { get; set; }
    public MediaCategory Category { get; set; }
    public string? UploadedByUserId { get; set; }
    public ApplicationUser? UploadedByUser { get; set; }
    public ICollection<PostMedia> Posts { get; set; } = new List<PostMedia>();
    public ICollection<LessonMedia> Lessons { get; set; } = new List<LessonMedia>();
}

public class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public PostType Type { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishedAtUtc { get; set; }
    public ICollection<PostMedia> Media { get; set; } = new List<PostMedia>();
}

public class PostMedia : BaseEntity
{
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    public int MediaId { get; set; }
    public Media Media { get; set; } = null!;
    public int DisplayOrder { get; set; }
}

public class LessonMedia : BaseEntity
{
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
    public int MediaId { get; set; }
    public Media Media { get; set; } = null!;
    public int DisplayOrder { get; set; }
}

public class AttendanceSession : BaseEntity
{
    public DateOnly Date { get; set; }
    public string? Notes { get; set; }
    public int ClassScheduleId { get; set; }
    public ClassSchedule ClassSchedule { get; set; } = null!;
    public ICollection<AttendanceRecord> Records { get; set; } = new List<AttendanceRecord>();
}

public class AttendanceRecord : BaseEntity
{
    public int AttendanceSessionId { get; set; }
    public AttendanceSession AttendanceSession { get; set; } = null!;
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public AttendanceStatus Status { get; set; }
    public DateTime? MarkedAtUtc { get; set; }
    public string? Notes { get; set; }
}

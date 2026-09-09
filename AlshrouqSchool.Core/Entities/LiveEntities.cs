namespace AlshrouqSchool.Core.Entities;

public class LiveSession : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public DateTime ScheduledStartAtUtc { get; set; }
    public DateTime? StartedAtUtc { get; set; }
    public DateTime? EndedAtUtc { get; set; }
    public string RoomName { get; set; } = string.Empty;
    public string? RecordingUrl { get; set; }
    public LiveSessionStatus Status { get; set; } = LiveSessionStatus.Scheduled;
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;
    public ICollection<StudentLiveSessionAttendance> StudentAttendances { get; set; } = new List<StudentLiveSessionAttendance>();
}

public class StudentLiveSessionAttendance : BaseEntity
{
    public int LiveSessionId { get; set; }
    public LiveSession LiveSession { get; set; } = null!;
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public DateTime JoinedAtUtc { get; set; }
    public DateTime? LeftAtUtc { get; set; }
    // Duration is computed at query time; do not persist a value that becomes stale while connected.
}

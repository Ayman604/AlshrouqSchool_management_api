namespace AlshrouqSchool.Core.Entities;

public class AcademicYear : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateOnly StartsOn { get; set; }
    public DateOnly EndsOn { get; set; }
    public bool IsCurrent { get; set; }
    public ICollection<Section> Sections { get; set; } = new List<Section>();
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
}

public class GradeLevel : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int LevelNumber { get; set; }
    public ICollection<Section> Sections { get; set; } = new List<Section>();
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}

public class Section : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int GradeLevelId { get; set; }
    public GradeLevel GradeLevel { get; set; } = null!;
    public int AcademicYearId { get; set; }
    public AcademicYear AcademicYear { get; set; } = null!;
    public ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
    public ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
}

public class Subject : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int GradeLevelId { get; set; }
    public GradeLevel GradeLevel { get; set; } = null!;
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}

public class TeachingAssignment : BaseEntity
{
    // The explicit join entity expresses exactly which teacher teaches which subject to which section.
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;
    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;
    public int AcademicYearId { get; set; }
    public AcademicYear AcademicYear { get; set; } = null!;
    public ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
}

public class ClassSchedule : BaseEntity
{
    public DayOfWeekType Day { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string? Room { get; set; }
    public int TeachingAssignmentId { get; set; }
    public TeachingAssignment TeachingAssignment { get; set; } = null!;
    public ICollection<AttendanceSession> AttendanceSessions { get; set; } = new List<AttendanceSession>();
}

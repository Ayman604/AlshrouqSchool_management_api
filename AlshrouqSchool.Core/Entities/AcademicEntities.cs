using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlshrouqSchool.Core.Entities;

public class AcademicYear : BaseEntity
{
    [Required]
    [StringLength(100,MinimumLength =4)]
    [Display(Name = "السنة الدراسية")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "تاريخ البداية")]
    public DateOnly StartsOn { get; set; }

    [Required]
    [Display(Name = "تاريخ النهاية")]
    public DateOnly EndsOn { get; set; }

    [Display(Name = "السنة الحالية")]
    public bool IsCurrent { get; set; }

    public ICollection<Section> Sections { get; set; } = new List<Section>();
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
}

public class GradeLevel : BaseEntity
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    [Display(Name = "المرحلة الدراسية")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Range(1, 15)]
    [Display(Name = "رقم المرحلة")]
    public int LevelNumber { get; set; }

    public ICollection<Section> Sections { get; set; } = new List<Section>();
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}

public class Section : BaseEntity
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    [Display(Name = "اسم الفصل")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 100)]
    [Display(Name = "السعة")]
    public int Capacity { get; set; }

    [Required]
    [ForeignKey(nameof(GradeLevel))]
    [Display(Name = "المرحلة الدراسية")]
    public int GradeLevelId { get; set; }

    [Required]
    [ForeignKey(nameof(AcademicYear))]
    [Display(Name = "السنة الدراسية")]
    public int AcademicYearId { get; set; }

    [StringLength(1)]
    [RegularExpression(@"^[MF]?$", ErrorMessage = "يجب أن يكون M أو F ")]
    [Display(Name = "الجنس (M/F)")]
    [Required]
    public required string Gender { get; set; } // 'M' = Male, 'F' = Female, null = Mixed

    #region Navigation properties
    public GradeLevel GradeLevel { get; set; } = null!;
    public AcademicYear AcademicYear { get; set; } = null!;
    public ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
    public ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
    public ICollection<LessonSection> LessonSections { get; set; } = new List<LessonSection>();
    #endregion
}

public class Subject : BaseEntity
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    [Display(Name = "المادة الدراسية")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(20, MinimumLength = 2)]
    [Display(Name = "كود المادة")]
    public string Code { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "الوصف")]
    public string? Description { get; set; }

    [Required]
    [ForeignKey(nameof(GradeLevel))]
    [Display(Name = "المرحلة الدراسية")]
    public int GradeLevelId { get; set; }

    #region Navigation properties
    public GradeLevel GradeLevel { get; set; } = null!;
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>(); 
    #endregion
}

public class TeachingAssignment : BaseEntity
{
    // The explicit join entity expresses exactly which teacher teaches which subject to which section.
    #region Foriegn Keys
    [Required]
    [ForeignKey(nameof(Teacher))]
    [Display(Name = "المعلم")]
    public int TeacherId { get; set; }

    [Required]
    [ForeignKey(nameof(Section))]
    [Display(Name = "الفصل")]
    public int SectionId { get; set; }

    [Required]
    [ForeignKey(nameof(Subject))]
    [Display(Name = "المادة")]
    public int SubjectId { get; set; }

    [Required]
    [ForeignKey(nameof(AcademicYear))]
    [Display(Name = "السنة الدراسية")]
    public int AcademicYearId { get; set; } 
    #endregion

    #region Navigation properties 
    public Teacher Teacher { get; set; } = null!;
    public Section Section { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
    public AcademicYear AcademicYear { get; set; } = null!;
    public ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>(); 
    #endregion
}

public class ClassSchedule : BaseEntity
{
    [Required]
    [Display(Name = "اليوم")]
    public DayOfWeekType Day { get; set; }

    [Required]
    [Display(Name = "وقت البداية")]
    public TimeOnly StartTime { get; set; }

    [Required]
    [Display(Name = "وقت النهاية")]
    public TimeOnly EndTime { get; set; }

    [StringLength(50)]
    [Display(Name = "الفصل/القاعة")]
    public string? Room { get; set; }

    [Required]
    [ForeignKey(nameof(TeachingAssignment))]
    public int TeachingAssignmentId { get; set; }

    #region Navigation properties
    public TeachingAssignment TeachingAssignment { get; set; } = null!;
    public ICollection<AttendanceSession> AttendanceSessions { get; set; } = new List<AttendanceSession>(); 
    #endregion
}

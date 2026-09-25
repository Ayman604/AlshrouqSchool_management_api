using AlshrouqSchool.Core.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlshrouqSchool.Core.Entities;

public class Teacher : BaseEntity
{
    [Required]
    [StringLength(450)]
    [ForeignKey(nameof(User))]
    [Display(Name = "معرف المستخدم")]
    public string UserId { get; set; } = string.Empty;

    [StringLength(20)]
    [Display(Name = "رقم الموظف")]
    public string? EmployeeNumber { get; set; }

    [Display(Name = "تاريخ التعيين")]
    public DateOnly? HireDate { get; set; }

    [StringLength(50)]
    [Display(Name = "الجنسية")]
    public string? Nationality { get; set; }

    [StringLength(1000)]
    [Display(Name = "السيرة الذاتية")]
    public string? Bio { get; set; }

    [StringLength(1)]
    [RegularExpression(@"^[MF]?$", ErrorMessage = "يجب أن يكون M أو F ")]
    [Display(Name = "الجنس (M/F)")]
    [Required]
    public required string Gender { get; set; } // 'M' = Male, 'F' = Female, null = Mixed


    // Navigation properties
    public ApplicationUser User { get; set; } = null!;
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    public ICollection<LiveSession> LiveSessions { get; set; } = new List<LiveSession>();
}

public class Student : BaseEntity
{
    [Required]
    [StringLength(450)]
    [ForeignKey(nameof(User))]
    [Display(Name = "معرف المستخدم")]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [Display(Name = "رقم الطالب")]
    public string StudentNumber { get; set; } = string.Empty;

    [Required]
    [Display(Name = "تاريخ الميلاد")]
    public DateOnly DateOfBirth { get; set; }

    [StringLength(1)]
    [RegularExpression(@"^[MF]?$", ErrorMessage = "يجب أن يكون M أو F ")]
    [Display(Name = "الجنس (M/F)")]
    [Required]
    public required string Gender { get; set; } // 'M' = Male, 'F' = Female, null = Mixed


    // Navigation properties
    public ApplicationUser User { get; set; } = null!;
    public ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();
    public ICollection<StudentParent> Parents { get; set; } = new List<StudentParent>();
    public ICollection<StudentQuizAttempt> QuizAttempts { get; set; } = new List<StudentQuizAttempt>();
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    public ICollection<StudentLiveSessionAttendance> LiveSessionAttendances { get; set; } = new List<StudentLiveSessionAttendance>();
}

public class Parent : BaseEntity
{
    [Required]
    [StringLength(450)]
    [ForeignKey(nameof(User))]
    [Display(Name = "معرف المستخدم")]
    public string UserId { get; set; } = string.Empty;

    // Navigation properties
    public ApplicationUser User { get; set; } = null!;
    public ICollection<StudentParent> Students { get; set; } = new List<StudentParent>();
}

public class StudentParent : BaseEntity
{
    [Required]
    [ForeignKey(nameof(Student))]
    [Display(Name = "الطالب")]
    public int StudentId { get; set; }

    [Required]
    [ForeignKey(nameof(Parent))]
    [Display(Name = "ولي الأمر")]
    public int ParentId { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "العلاقة")]
    public string Relationship { get; set; } = string.Empty; // "Father", "Mother", "Guardian"

    [Display(Name = "جهة الاتصال الأساسية")]
    public bool IsPrimaryContact { get; set; }

    // Navigation properties
    public Student Student { get; set; } = null!;
    public Parent Parent { get; set; } = null!;
}

public class StudentEnrollment : BaseEntity
{
    [Required]
    [ForeignKey(nameof(Student))]
    [Display(Name = "الطالب")]
    public int StudentId { get; set; }

    [Required]
    [ForeignKey(nameof(Section))]
    [Display(Name = "الفصل")]
    public int SectionId { get; set; }

    [Required]
    [Display(Name = "تاريخ الالتحاق")]
    public DateOnly EnrolledOn { get; set; }

    [Display(Name = "تاريخ الانسحاب")]
    public DateOnly? LeftOn { get; set; }

    [Display(Name = "نشط")]
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public Student Student { get; set; } = null!;
    public Section Section { get; set; } = null!;
}

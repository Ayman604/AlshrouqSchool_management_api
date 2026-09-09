using AlshrouqSchool.Core.Entities.Identity;

namespace AlshrouqSchool.Core.Entities;

public class Teacher : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;
    public string? EmployeeNumber { get; set; }
    public DateOnly? HireDate { get; set; }
    public string? Nationality { get; set; }
    public string? Bio { get; set; }
    public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    public ICollection<LiveSession> LiveSessions { get; set; } = new List<LiveSession>();
}

public class Student : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;
    public string StudentNumber { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();
    public ICollection<StudentParent> Parents { get; set; } = new List<StudentParent>();
    public ICollection<StudentQuizAttempt> QuizAttempts { get; set; } = new List<StudentQuizAttempt>();
}

public class Parent : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;
    public ICollection<StudentParent> Students { get; set; } = new List<StudentParent>();
}

public class StudentParent : BaseEntity
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int ParentId { get; set; }
    public Parent Parent { get; set; } = null!;
    public string Relationship { get; set; } = string.Empty;
    public bool IsPrimaryContact { get; set; }
}

public class StudentEnrollment : BaseEntity
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;
    public DateOnly EnrolledOn { get; set; }
    public DateOnly? LeftOn { get; set; }
    public bool IsActive { get; set; } = true;
}

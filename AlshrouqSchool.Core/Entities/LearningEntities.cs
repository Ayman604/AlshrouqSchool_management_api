namespace AlshrouqSchool.Core.Entities;

public class Lesson : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishedAtUtc { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;
    public ICollection<LessonSection> Sections { get; set; } = new List<LessonSection>();
    public ICollection<LessonMedia> Media { get; set; } = new List<LessonMedia>();
    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    public ICollection<LiveSession> LiveSessions { get; set; } = new List<LiveSession>();
}

public class LessonSection : BaseEntity
{
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;
}

public class Quiz : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal TotalMarks { get; set; }
    public decimal PassingMarks { get; set; }
    public int DurationMinutes { get; set; }
    public DateTime? OpensAtUtc { get; set; }
    public DateTime? ClosesAtUtc { get; set; }
    public bool IsPublished { get; set; }
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<StudentQuizAttempt> Attempts { get; set; } = new List<StudentQuizAttempt>();
}

public class Question : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public decimal Marks { get; set; }
    public int DisplayOrder { get; set; }
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;
    public ICollection<AnswerChoice> Choices { get; set; } = new List<AnswerChoice>();
}

public class AnswerChoice : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public int DisplayOrder { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;
}

public class StudentQuizAttempt : BaseEntity
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;
    public DateTime StartedAtUtc { get; set; }
    public DateTime? SubmittedAtUtc { get; set; }
    public decimal Score { get; set; }
    public ICollection<StudentAnswer> Answers { get; set; } = new List<StudentAnswer>();
}

public class StudentAnswer : BaseEntity
{
    public int StudentQuizAttemptId { get; set; }
    public StudentQuizAttempt StudentQuizAttempt { get; set; } = null!;
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;
    public int? SelectedAnswerChoiceId { get; set; }
    public AnswerChoice? SelectedAnswerChoice { get; set; }
    public bool IsCorrect { get; set; }
    public decimal AwardedMarks { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlshrouqSchool.Core.Entities;

public class Lesson : BaseEntity
{
    [Required]
    [StringLength(250, MinimumLength = 5)]
    [Display(Name = "عنوان الدرس")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Display(Name = "محتوى الدرس")]
    public string Content { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    [Display(Name = "ترتيب العرض")]
    public int DisplayOrder { get; set; }

    [Display(Name = "منشور")]
    public bool IsPublished { get; set; }

    [Display(Name = "تاريخ النشر")]
    public DateTime? PublishedAtUtc { get; set; }


    #region Foreign Keys

    [ForeignKey(nameof(Teacher))]
    [Display(Name = "المعلم")]
    public int TeacherId { get; set; }

    [Required]
    [ForeignKey(nameof(Subject))]
    [Display(Name = "المادة")]
    public int SubjectId { get; set; } 
    #endregion

    #region Navigation properties
    public Teacher Teacher { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
    public ICollection<LessonSection> Sections { get; set; } = new List<LessonSection>();
    public ICollection<LessonMedia> Media { get; set; } = new List<LessonMedia>();
    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    public ICollection<LiveSession> LiveSessions { get; set; } = new List<LiveSession>(); 
    #endregion
}

public class LessonSection : BaseEntity
{
    [Required]
    [ForeignKey(nameof(Lesson))]
    public int LessonId { get; set; }

    [Required]
    [ForeignKey(nameof(Section))]
    public int SectionId { get; set; }

    // Navigation properties
    public Lesson Lesson { get; set; } = null!;
    public Section Section { get; set; } = null!;
}

public class Quiz : BaseEntity
{
    [Required]
    [StringLength(250, MinimumLength = 5)]
    [Display(Name = "عنوان الاختبار")]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    [Display(Name = "وصف الاختبار")]
    public string? Description { get; set; }

    [Required]
    [Range(1, 1000)]
    [Display(Name = "إجمالي الدرجات")]
    public decimal TotalMarks { get; set; }

    [Required]
    [Range(0, 1000)]
    [Display(Name = "درجة النجاح")]
    public decimal PassingMarks { get; set; }

    [Required]
    [Range(1, 480)]
    [Display(Name = "مدة الاختبار (دقيقة)")]
    public int DurationMinutes { get; set; }

    [Display(Name = "وقت الفتح")]
    public DateTime? OpensAtUtc { get; set; }

    [Display(Name = "وقت الإغلاق")]
    public DateTime? ClosesAtUtc { get; set; }

    [Display(Name = "منشور")]
    public bool IsPublished { get; set; }

    [Display(Name = "خلط الأسئلة")]
    public bool ShuffleQuestions { get; set; }

    [Display(Name = "خلط الخيارات")]
    public bool ShuffleAnswerChoices { get; set; }

    [Required]
    [ForeignKey(nameof(Lesson))]
    [Display(Name = "الدرس")]
    public int LessonId { get; set; }

    
    #region Navigation properties
    public Lesson Lesson { get; set; } = null!;
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<StudentQuizAttempt> Attempts { get; set; } = new List<StudentQuizAttempt>(); 
    #endregion
}

public class Question : BaseEntity
{
    [Required]
    [StringLength(1000)]
    [Display(Name = "نص السؤال")]
    public string Text { get; set; } = string.Empty;

    [Required]
    [Range(1, 100)]
    [Display(Name = "درجات السؤال")]
    public decimal Marks { get; set; }

    [Required]
    [Range(1, 1000)]
    [Display(Name = "ترتيب العرض")]
    public int DisplayOrder { get; set; }

    [Required]
    [ForeignKey(nameof(Quiz))]
    public int QuizId { get; set; }


    #region Navigation properties
    public Quiz Quiz { get; set; } = null!;
    public ICollection<AnswerChoice> Choices { get; set; } = new List<AnswerChoice>(); 
    #endregion
}

public class AnswerChoice : BaseEntity
{
    [Required]
    [StringLength(500)]
    [Display(Name = "نص الخيار")]
    public string Text { get; set; } = string.Empty;

    [Display(Name = "الإجابة الصحيحة")]
    public bool IsCorrect { get; set; }

    [Required]
    [Range(1, 1000)]
    [Display(Name = "ترتيب العرض")]
    public int DisplayOrder { get; set; }

    [Required]
    [ForeignKey(nameof(Question))]
    public int QuestionId { get; set; }

    // Navigation properties
    public Question Question { get; set; } = null!;
}

public class StudentQuizAttempt : BaseEntity
{
    [Required]
    [ForeignKey(nameof(Student))]
    [Display(Name = "الطالب")]
    public int StudentId { get; set; }

    [Required]
    [ForeignKey(nameof(Quiz))]
    [Display(Name = "الاختبار")]
    public int QuizId { get; set; }

    [Required]
    [Display(Name = "بدء الحل")]
    public DateTime StartedAtUtc { get; set; }

    [Display(Name = "تسليم الحل")]
    public DateTime? SubmittedAtUtc { get; set; }

    [Range(0, 10000)]
    [Display(Name = "الدرجة")]
    public decimal Score { get; set; }

    // JSON: [1, 3, 2, 5] - ترتيب الأسئلة اللي شافها الطالب
    [StringLength(2000)]
    public string? QuestionOrderJson { get; set; }

    // JSON: { "1": [2, 1, 3], "2": [4, 2, 1, 3] }
    [StringLength(5000)]
    public string? AnswerChoiceOrderJson { get; set; }

    // Navigation properties
    public Student Student { get; set; } = null!;
    public Quiz Quiz { get; set; } = null!;
    public ICollection<StudentAnswer> Answers { get; set; } = new List<StudentAnswer>();
}

public class StudentAnswer : BaseEntity
{
    [Required]
    [ForeignKey(nameof(StudentQuizAttempt))]
    public int StudentQuizAttemptId { get; set; }

    [Required]
    [ForeignKey(nameof(Question))]
    public int QuestionId { get; set; }

    [ForeignKey(nameof(SelectedAnswerChoice))]
    public int? SelectedAnswerChoiceId { get; set; }

    [Display(Name = "إجابة صحيحة")]
    public bool IsCorrect { get; set; }

    [Range(0, 1000)]
    [Display(Name = "درجات الممنوحة")]
    public decimal AwardedMarks { get; set; }

    // Navigation properties
    public StudentQuizAttempt StudentQuizAttempt { get; set; } = null!;
    public Question Question { get; set; } = null!;
    public AnswerChoice? SelectedAnswerChoice { get; set; }
}

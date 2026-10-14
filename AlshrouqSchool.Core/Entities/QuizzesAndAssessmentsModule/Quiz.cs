using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.LessonsAndTeachingModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.QuizzesAndAssessmentsModule
{
    public class Quiz : BaseEntity<int>
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
}

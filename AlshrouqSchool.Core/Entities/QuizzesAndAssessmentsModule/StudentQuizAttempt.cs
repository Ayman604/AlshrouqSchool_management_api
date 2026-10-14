using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.UsersModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.QuizzesAndAssessmentsModule
{
    public class StudentQuizAttempt : BaseEntity<int>
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
}

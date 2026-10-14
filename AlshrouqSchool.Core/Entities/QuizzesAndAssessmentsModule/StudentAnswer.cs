using AlshrouqSchool.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.QuizzesAndAssessmentsModule
{
    public class StudentAnswer : BaseEntity<int>
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
}

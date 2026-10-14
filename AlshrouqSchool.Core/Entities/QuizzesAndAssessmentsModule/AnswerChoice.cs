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
    public class AnswerChoice : BaseEntity<int>
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
}

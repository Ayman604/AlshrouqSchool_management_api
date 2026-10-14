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
    public class Question : BaseEntity<int>
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

}

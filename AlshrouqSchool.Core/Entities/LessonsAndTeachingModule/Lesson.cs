using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.AcademicModule;
using AlshrouqSchool.Domain.Entities.LiveSessionsModule;
using AlshrouqSchool.Domain.Entities.QuizzesAndAssessmentsModule;
using AlshrouqSchool.Domain.Entities.UsersModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.LessonsAndTeachingModule
{
    public class Lesson : BaseEntity<int>
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
}

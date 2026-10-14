using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.AcademicModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.LessonsAndTeachingModule
{
    public class LessonSection : BaseEntity<int>
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
}

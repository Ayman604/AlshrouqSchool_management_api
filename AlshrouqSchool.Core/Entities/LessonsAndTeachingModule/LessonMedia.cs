using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.MediaAndContentModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.LessonsAndTeachingModule
{
    public class LessonMedia : BaseEntity<int>
    {
        [Required]
        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }

        [Required]
        [ForeignKey(nameof(Media))]
        public int MediaId { get; set; }

        [Required]
        [Display(Name = "دور الوسيط")]
        public MediaRole MediaRole { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "ترتيب العرض")]
        public int DisplayOrder { get; set; }

        // Navigation properties
        public Lesson Lesson { get; set; } = null!;
        public Media Media { get; set; } = null!;

    }
}

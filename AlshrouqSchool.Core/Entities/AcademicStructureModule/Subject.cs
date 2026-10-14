using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.LessonsAndTeachingModule;
using AlshrouqSchool.Domain.Entities.TeachingAssignmentsModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.AcademicModule
{
    public class Subject : BaseEntity<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "المادة الدراسية")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "كود المادة")]
        public string Code { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }

        [Required]
        [ForeignKey(nameof(GradeLevel))]
        [Display(Name = "المرحلة الدراسية")]
        public int GradeLevelId { get; set; }

        #region Navigation properties
        public GradeLevel GradeLevel { get; set; } = null!;
        public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        #endregion
    }
}

using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.LessonsAndTeachingModule;
using AlshrouqSchool.Domain.Entities.TeachingAssignmentsModule;
using AlshrouqSchool.Domain.Entities.UsersModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.AcademicModule
{
    public class Section : BaseEntity<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "اسم الفصل")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 100)]
        [Display(Name = "السعة")]
        public int Capacity { get; set; }

        [Required]
        [ForeignKey(nameof(GradeLevel))]
        [Display(Name = "المرحلة الدراسية")]
        public int GradeLevelId { get; set; }

        [Required]
        [ForeignKey(nameof(AcademicYear))]
        [Display(Name = "السنة الدراسية")]
        public int AcademicYearId { get; set; }

        [StringLength(1)]
        [RegularExpression(@"^[MF]?$", ErrorMessage = "يجب أن يكون M أو F ")]
        [Display(Name = "الجنس (M/F)")]
        [Required]
        public required string Gender { get; set; } // 'M' = Male, 'F' = Female, null = Mixed

        #region Navigation properties
        public GradeLevel GradeLevel { get; set; } = null!;
        public AcademicYear AcademicYear { get; set; } = null!;
        public ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();
        public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
        public ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
        public ICollection<LessonSection> LessonSections { get; set; } = new List<LessonSection>();
        #endregion
    }

}

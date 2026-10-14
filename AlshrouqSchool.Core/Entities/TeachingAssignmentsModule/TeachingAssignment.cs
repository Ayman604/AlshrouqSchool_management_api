using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.AcademicModule;
using AlshrouqSchool.Domain.Entities.UsersModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.TeachingAssignmentsModule
{
    public class TeachingAssignment : BaseEntity<int>
    {
        // The explicit join entity expresses exactly which teacher teaches which subject to which section.
        #region Foriegn Keys
        [Required]
        [ForeignKey(nameof(Teacher))]
        [Display(Name = "المعلم")]
        public int TeacherId { get; set; }

        [Required]
        [ForeignKey(nameof(Section))]
        [Display(Name = "الفصل")]
        public int SectionId { get; set; }

        [Required]
        [ForeignKey(nameof(Subject))]
        [Display(Name = "المادة")]
        public int SubjectId { get; set; }

        [Required]
        [ForeignKey(nameof(AcademicYear))]
        [Display(Name = "السنة الدراسية")]
        public int AcademicYearId { get; set; }
        #endregion

        #region Navigation properties 
        public Teacher Teacher { get; set; } = null!;
        public Section Section { get; set; } = null!;
        public Subject Subject { get; set; } = null!;
        public AcademicYear AcademicYear { get; set; } = null!;
        public ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
        #endregion
    }
}

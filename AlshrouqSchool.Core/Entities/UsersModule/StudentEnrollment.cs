using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.AcademicModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.UsersModule
{
    public class StudentEnrollment : BaseEntity<int>
    {
        [Required]
        [ForeignKey(nameof(Student))]
        [Display(Name = "الطالب")]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey(nameof(Section))]
        [Display(Name = "الفصل")]
        public int SectionId { get; set; }

        [Required]
        [Display(Name = "تاريخ الالتحاق")]
        public DateOnly EnrolledOn { get; set; }

        [Display(Name = "تاريخ الانسحاب")]
        public DateOnly? LeftOn { get; set; }

        [Display(Name = "نشط")]
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public Student Student { get; set; } = null!;
        public Section Section { get; set; } = null!;
    }
}

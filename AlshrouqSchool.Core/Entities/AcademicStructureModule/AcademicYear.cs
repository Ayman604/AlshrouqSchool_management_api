using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.TeachingAssignmentsModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.AcademicModule
{
    public class AcademicYear : BaseEntity<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        [Display(Name = "السنة الدراسية")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "تاريخ البداية")]
        public DateOnly StartsOn { get; set; }

        [Required]
        [Display(Name = "تاريخ النهاية")]
        public DateOnly EndsOn { get; set; }

        [Display(Name = "السنة الحالية")]
        public bool IsCurrent { get; set; }

        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
    }
}

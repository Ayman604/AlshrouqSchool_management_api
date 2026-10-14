using AlshrouqSchool.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.AcademicModule
{
    public class GradeLevel : BaseEntity<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "المرحلة الدراسية")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 15)]
        [Display(Name = "رقم المرحلة")]
        public int LevelNumber { get; set; }

        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}

using AlshrouqSchool.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.UsersModule
{
    public class StudentParent : BaseEntity<int>
    {
        [Required]
        [ForeignKey(nameof(Student))]
        [Display(Name = "الطالب")]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey(nameof(Parent))]
        [Display(Name = "ولي الأمر")]
        public int ParentId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "العلاقة")]
        public string Relationship { get; set; } = string.Empty; // "Father", "Mother", "Guardian"

        [Display(Name = "جهة الاتصال الأساسية")]
        public bool IsPrimaryContact { get; set; }

        // Navigation properties
        public Student Student { get; set; } = null!;
        public Parent Parent { get; set; } = null!;
    }
}

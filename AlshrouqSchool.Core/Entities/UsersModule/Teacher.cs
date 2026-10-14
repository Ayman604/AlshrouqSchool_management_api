using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Entities.Identity;
using AlshrouqSchool.Domain.Entities.LessonsAndTeachingModule;
using AlshrouqSchool.Domain.Entities.LiveSessionsModule;
using AlshrouqSchool.Domain.Entities.TeachingAssignmentsModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.UsersModule
{
    public class Teacher : BaseEntity<int>
    {
        [Required]
        [StringLength(450)]
        [ForeignKey(nameof(User))]
        [Display(Name = "معرف المستخدم")]
        public string UserId { get; set; } = string.Empty;

        [StringLength(20)]
        [Display(Name = "رقم الموظف")]
        public string? EmployeeNumber { get; set; }

        [Display(Name = "تاريخ التعيين")]
        public DateOnly? HireDate { get; set; }

        [StringLength(50)]
        [Display(Name = "الجنسية")]
        public string? Nationality { get; set; }

        [StringLength(1000)]
        [Display(Name = "السيرة الذاتية")]
        public string? Bio { get; set; }

        [StringLength(1)]
        [RegularExpression(@"^[MF]?$", ErrorMessage = "يجب أن يكون M أو F ")]
        [Display(Name = "الجنس (M/F)")]
        [Required]
        public required string Gender { get; set; } // 'M' = Male, 'F' = Female, null = Mixed


        // Navigation properties
        public ApplicationUser User { get; set; } = null!;
        public ICollection<TeachingAssignment> TeachingAssignments { get; set; } = new List<TeachingAssignment>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<LiveSession> LiveSessions { get; set; } = new List<LiveSession>();
    }
}

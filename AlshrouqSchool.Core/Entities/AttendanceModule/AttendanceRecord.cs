using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.UsersModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.AttendanceModule
{
    public class AttendanceRecord : BaseEntity<int>
    {
        [Required]
        [ForeignKey(nameof(AttendanceSession))]
        public int AttendanceSessionId { get; set; }

        [Required]
        [ForeignKey(nameof(Student))]
        [Display(Name = "الطالب")]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "الحالة")]
        public AttendanceStatus Status { get; set; }

        [Display(Name = "وقت التسجيل")]
        public DateTime? MarkedAtUtc { get; set; }

        [StringLength(500)]
        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        // Navigation properties
        public AttendanceSession AttendanceSession { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}


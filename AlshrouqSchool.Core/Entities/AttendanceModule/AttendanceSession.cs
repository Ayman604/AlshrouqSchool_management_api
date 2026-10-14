using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.TeachingAssignmentsModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.AttendanceModule
{
    public class AttendanceSession : BaseEntity<int>
    {
        [Required]
        [Display(Name = "التاريخ")]
        public DateOnly Date { get; set; }

        [StringLength(500)]
        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        [Required]
        [ForeignKey(nameof(ClassSchedule))]
        public int ClassScheduleId { get; set; }

        // Navigation properties
        public ClassSchedule ClassSchedule { get; set; } = null!;
        public ICollection<AttendanceRecord> Records { get; set; } = new List<AttendanceRecord>();
    }
}

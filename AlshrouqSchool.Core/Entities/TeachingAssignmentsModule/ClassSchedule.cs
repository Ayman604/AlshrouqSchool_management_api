using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.AttendanceModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.TeachingAssignmentsModule
{
    public class ClassSchedule : BaseEntity<int>
    {
        [Required]
        [Display(Name = "اليوم")]
        public DayOfWeekType Day { get; set; }

        [Required]
        [Display(Name = "وقت البداية")]
        public TimeOnly StartTime { get; set; }

        [Required]
        [Display(Name = "وقت النهاية")]
        public TimeOnly EndTime { get; set; }

        [StringLength(50)]
        [Display(Name = "الفصل/القاعة")]
        public string? Room { get; set; }

        [Required]
        [ForeignKey(nameof(TeachingAssignment))]
        public int TeachingAssignmentId { get; set; }

        #region Navigation properties
        public TeachingAssignment TeachingAssignment { get; set; } = null!;
        public ICollection<AttendanceSession> AttendanceSessions { get; set; } = new List<AttendanceSession>();
        #endregion
    }

}

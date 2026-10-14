using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Domain.Entities.UsersModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.LiveSessionsModule
{
    public class StudentLiveSessionAttendance : BaseEntity<int>
    {
        [Required]
        [ForeignKey(nameof(LiveSession))]
        public int LiveSessionId { get; set; }

        [Required]
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "وقت الدخول")]
        public DateTime JoinedAtUtc { get; set; }

        [Display(Name = "وقت الخروج")]
        public DateTime? LeftAtUtc { get; set; }

        // Navigation properties
        public LiveSession LiveSession { get; set; } = null!;
        public Student Student { get; set; } = null!;

    }
}

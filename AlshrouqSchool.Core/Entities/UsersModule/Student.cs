using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Entities.Identity;
using AlshrouqSchool.Domain.Entities.AttendanceModule;
using AlshrouqSchool.Domain.Entities.LiveSessionsModule;
using AlshrouqSchool.Domain.Entities.QuizzesAndAssessmentsModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.UsersModule
{
    public class Student : BaseEntity<int>
    {
        [Required]
        [StringLength(450)]
        [ForeignKey(nameof(User))]
        [Display(Name = "معرف المستخدم")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "رقم الطالب")]
        public string StudentNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "تاريخ الميلاد")]
        public DateOnly DateOfBirth { get; set; }

        [StringLength(1)]
        [RegularExpression(@"^[MF]?$", ErrorMessage = "يجب أن يكون M أو F ")]
        [Display(Name = "الجنس (M/F)")]
        [Required]
        public required string Gender { get; set; } // 'M' = Male, 'F' = Female, null = Mixed


        // Navigation properties
        public ApplicationUser User { get; set; } = null!;
        public ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();
        public ICollection<StudentParent> Parents { get; set; } = new List<StudentParent>();
        public ICollection<StudentQuizAttempt> QuizAttempts { get; set; } = new List<StudentQuizAttempt>();
        public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
        public ICollection<StudentLiveSessionAttendance> LiveSessionAttendances { get; set; } = new List<StudentLiveSessionAttendance>();
    }
}

using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Domain.Entities.UsersModule
{
    public class Parent : BaseEntity<int>
    {
        [Required]
        [StringLength(450)]
        [ForeignKey(nameof(User))]
        [Display(Name = "معرف المستخدم")]
        public string UserId { get; set; } = string.Empty;

        // Navigation properties
        public ApplicationUser User { get; set; } = null!;
        public ICollection<StudentParent> Students { get; set; } = new List<StudentParent>();
    }
}

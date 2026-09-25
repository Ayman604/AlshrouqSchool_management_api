using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Posts.DTOs
{
    // DTO للبيانات العائدة للعميل (تُرجع البيانات المطلوبة فقط بدون العلاقات المعقدة)
    public record PostDto(int Id, string Title, string Content, DateTime? CreatedAt) : BaseDto(Id); 

    // DTO لإنشاء منشور جديد
    public record CreatePostDto(string Title, string Content);

    // DTO لتحديث منشور
    public record UpdatePostDto(string Title, string Content);
}

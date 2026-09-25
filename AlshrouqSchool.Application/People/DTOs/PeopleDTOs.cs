using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.People.DTOs
{
    // Teacher DTOs
    public record TeacherDto(int Id, string UserId, string? EmployeeNumber, DateOnly? HireDate, string? Nationality, string? Bio, string Gender) : BaseDto(Id); 
    public record CreateTeacherDto(string UserId, string? EmployeeNumber, DateOnly? HireDate, string? Nationality, string? Bio, string Gender); 
    public record UpdateTeacherDto(string? EmployeeNumber, string? Nationality, string? Bio); 

    // Student DTOs
    public record StudentDto(int Id, string UserId, string StudentNumber, DateOnly DateOfBirth, string Gender) : BaseDto(Id); 
    public record CreateStudentDto(string UserId, string StudentNumber, DateOnly DateOfBirth, string Gender); 

    // Parent DTOs
    public record ParentDto(int Id, string UserId) : BaseDto(Id); 
    public record CreateParentDto(string UserId); 

    // StudentParent Link DTOs
    public record StudentParentDto(int Id, int StudentId, int ParentId, string Relationship, bool IsPrimaryContact) : BaseDto(Id);
    public record CreateStudentParentDto(int StudentId, int ParentId, string Relationship, bool IsPrimaryContact); 

    // StudentEnrollment DTOs
    public record StudentEnrollmentDto(int Id, int StudentId, int SectionId, DateOnly EnrolledOn, DateOnly? LeftOn, bool IsActive) : BaseDto(Id); 
    public record CreateStudentEnrollmentDto(int StudentId, int SectionId, DateOnly EnrolledOn); 
}

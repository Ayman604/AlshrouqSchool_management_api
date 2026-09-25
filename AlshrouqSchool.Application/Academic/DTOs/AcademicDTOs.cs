using AlshrouqSchool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Academic.DTOs
{
    // AcademicYear DTOs
    public record AcademicYearDto(int Id, string Name, DateOnly StartsOn, DateOnly EndsOn, bool IsCurrent) : BaseDto(Id); 
    public record CreateAcademicYearDto(string Name, DateOnly StartsOn, DateOnly EndsOn, bool IsCurrent); 
    public record UpdateAcademicYearDto(string Name, DateOnly StartsOn, DateOnly EndsOn, bool IsCurrent); 

    // GradeLevel DTOs
    public record GradeLevelDto(int Id, string Name, int LevelNumber) : BaseDto(Id); 
    public record CreateGradeLevelDto(string Name, int LevelNumber); 
    public record UpdateGradeLevelDto(string Name, int LevelNumber); 

    // Section DTOs
    public record SectionDto(int Id, string Name, int Capacity, int GradeLevelId, int AcademicYearId, string Gender) : BaseDto(Id);
    public record CreateSectionDto(string Name, int Capacity, int GradeLevelId, int AcademicYearId, string Gender); 
    public record UpdateSectionDto(string Name, int Capacity, int GradeLevelId, int AcademicYearId, string Gender); 

    // Subject DTOs
    public record SubjectDto(int Id, string Name, string Code, string? Description, int GradeLevelId) : BaseDto(Id);
    public record CreateSubjectDto(string Name, string Code, string? Description, int GradeLevelId); 
    public record UpdateSubjectDto(string Name, string Code, string? Description, int GradeLevelId); 

    // TeachingAssignment DTOs
    public record TeachingAssignmentDto(int Id, int TeacherId, int SectionId, int SubjectId, int AcademicYearId) : BaseDto(Id); 
    public record CreateTeachingAssignmentDto(int TeacherId, int SectionId, int SubjectId, int AcademicYearId); 
    // ClassSchedule DTOs
    public record ClassScheduleDto(int Id, DayOfWeekType Day, TimeOnly StartTime, TimeOnly EndTime, string? Room, int TeachingAssignmentId) : BaseDto(Id); 
    public record CreateClassScheduleDto(DayOfWeekType Day, TimeOnly StartTime, TimeOnly EndTime, string? Room, int TeachingAssignmentId);
}

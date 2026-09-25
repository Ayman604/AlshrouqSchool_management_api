using AlshrouqSchool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.ContentAndLive.DTOs
{
    // Media DTOs
    public record MediaDto(int Id, string FileName, string FilePath, string MimeType, long FileSizeBytes, string? AltText, MediaType Type, MediaCategory Category, string UploadedByUserId) : BaseDto(Id);
    public record CreateMediaDto(string FileName, string FilePath, string MimeType, long FileSizeBytes, string? AltText, MediaType Type, MediaCategory Category, string UploadedByUserId);

    // Attendance DTOs
    public record AttendanceSessionDto(int Id, DateOnly Date, string? Notes, int ClassScheduleId) : BaseDto(Id);
    public record CreateAttendanceSessionDto(DateOnly Date, string? Notes, int ClassScheduleId);

    public record AttendanceRecordDto(int Id, int AttendanceSessionId, int StudentId, AttendanceStatus Status, DateTime? MarkedAtUtc, string? Notes) : BaseDto(Id);
    public record MarkStudentAttendanceDto(int StudentId, AttendanceStatus Status, string? Notes);
    public record SaveAttendanceRecordListDto(int AttendanceSessionId, List<MarkStudentAttendanceDto> Records);

    // LiveSession DTOs
    public record LiveSessionDto(int Id, string Title, string? Description, DateTime ScheduledStartAtUtc, DateTime? StartedAtUtc, DateTime? EndedAtUtc, string RoomName, string? RecordingUrl, LiveSessionStatus Status, bool RecordingAvailable, int LessonId, int TeacherId, int SectionId) : BaseDto(Id);
    public record CreateLiveSessionDto(string Title, string? Description, DateTime ScheduledStartAtUtc, string RoomName, int LessonId, int TeacherId, int SectionId);
}
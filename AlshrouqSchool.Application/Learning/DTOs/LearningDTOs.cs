using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Learning.DTOs
{
    // Lesson DTOs
    public record LessonDto(int Id, string Title, string Content, int DisplayOrder, bool IsPublished, DateTime? PublishedAtUtc, int TeacherId, int SubjectId) : BaseDto(Id);
    public record CreateLessonDto(string Title, string Content, int DisplayOrder, bool IsPublished, int TeacherId, int SubjectId);

    // Quiz DTOs
    public record QuizDto(int Id, string Title, string? Description, decimal TotalMarks, decimal PassingMarks, int DurationMinutes, bool IsPublished, int LessonId) : BaseDto(Id);
    public record CreateQuizDto(string Title, string? Description, decimal TotalMarks, decimal PassingMarks, int DurationMinutes, int LessonId);

    // Question & AnswerChoice DTOs
    public record AnswerChoiceDto(int Id, string Text, bool IsCorrect, int DisplayOrder) : BaseDto(Id);
    public record CreateAnswerChoiceDto(string Text, bool IsCorrect, int DisplayOrder);

    public record QuestionDto(int Id, string Text, decimal Marks, int DisplayOrder, List<AnswerChoiceDto> Choices) : BaseDto(Id);
    public record CreateQuestionDto(string Text, decimal Marks, int DisplayOrder, int QuizId, List<CreateAnswerChoiceDto> Choices);

    // Student Quiz Attempt DTOs
    public record StudentQuizAttemptDto(int Id, int StudentId, int QuizId, DateTime StartedAtUtc, DateTime? SubmittedAtUtc, decimal Score) : BaseDto(Id); 
    public record StartQuizAttemptDto(int StudentId, int QuizId);
    public record SubmitStudentAnswerDto(int QuestionId, int? SelectedAnswerChoiceId);
    public record SubmitQuizAttemptDto(int AttemptId, List<SubmitStudentAnswerDto> Answers);
}

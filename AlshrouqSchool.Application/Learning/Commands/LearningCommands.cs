using AlshrouqSchool.Application.Learning.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Learning.Commands
{
    public record CreateLessonCommand(CreateLessonDto Dto) : IRequest<LessonDto>; 
    public record CreateQuizCommand(CreateQuizDto Dto) : IRequest<QuizDto>; 
    public record CreateQuestionCommand(CreateQuestionDto Dto) : IRequest<QuestionDto>; 
    public record StartQuizAttemptCommand(StartQuizAttemptDto Dto) : IRequest<StudentQuizAttemptDto>; 
    public record SubmitQuizAttemptCommand(SubmitQuizAttemptDto Dto) : IRequest<StudentQuizAttemptDto>; 
}

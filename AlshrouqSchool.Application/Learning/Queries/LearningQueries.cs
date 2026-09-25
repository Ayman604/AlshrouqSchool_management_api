using AlshrouqSchool.Application.Learning.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Learning.Queries
{
    public record GetLessonsBySubjectQuery(int SubjectId) : IRequest<List<LessonDto>>; 
    public record GetLessonByIdQuery(int Id) : IRequest<LessonDto?>; 
    public record GetQuizzesByLessonQuery(int LessonId) : IRequest<List<QuizDto>>; 
    public record GetQuizWithQuestionsQuery(int QuizId) : IRequest<QuizDto?>; 
}

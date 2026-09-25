using AlshrouqSchool.Application.People.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.People.Queries
{
    public record GetAllTeachersQuery() : IRequest<List<TeacherDto>>; 
    public record GetTeacherByIdQuery(int Id) : IRequest<TeacherDto?>; 
    public record GetAllStudentsQuery() : IRequest<List<StudentDto>>; 
    public record GetStudentByIdQuery(int Id) : IRequest<StudentDto?>; 
    public record GetStudentParentsQuery(int StudentId) : IRequest<List<StudentParentDto>>;
}

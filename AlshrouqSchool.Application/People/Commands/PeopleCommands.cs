using AlshrouqSchool.Application.People.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.People.Commands
{
    public record CreateTeacherCommand(CreateTeacherDto Dto) : IRequest<TeacherDto>; 
    public record UpdateTeacherCommand(int Id, UpdateTeacherDto Dto) : IRequest<bool>; 
    public record CreateStudentCommand(CreateStudentDto Dto) : IRequest<StudentDto>; 
    public record CreateParentCommand(CreateParentDto Dto) : IRequest<ParentDto>;
    public record LinkStudentParentCommand(CreateStudentParentDto Dto) : IRequest<StudentParentDto>; 
    public record EnrollStudentCommand(CreateStudentEnrollmentDto Dto) : IRequest<StudentEnrollmentDto>; 

}

using AlshrouqSchool.Application.Academic.DTOs;
using AlshrouqSchool.Application.Academic.Queries;
using AlshrouqSchool.Application.Posts.DTOs;
using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlshrouqSchool.Application.Academic.Commands
{

    public record DeleteAcademicYearCommand(int Id) : IRequest<bool>;


    public class DeleteAcademicYearCommandHandler(IAcademicYearRepository academicYearRepository) : IRequestHandler<DeleteAcademicYearCommand, bool>
    {
        public async Task<bool> Handle(DeleteAcademicYearCommand request, CancellationToken cancellationToken)
        {
            var result = await academicYearRepository.DeleteAsync(request.Id);
            if (result) await academicYearRepository.save();
            return result;
        }
    }
    
}

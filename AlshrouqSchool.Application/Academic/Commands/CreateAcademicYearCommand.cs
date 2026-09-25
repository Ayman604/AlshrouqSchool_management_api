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
using static AlshrouqSchool.Application.Academic.Commands.DeleteAcademicYearCommand;

namespace AlshrouqSchool.Application.Academic.Commands
{
    
        // AcademicYear Commands
        public record CreateAcademicYearCommand(CreateAcademicYearDto Dto) : IRequest<AcademicYearDto>; 
       
    public class CreateAcademicYearCommandHandler(IAcademicYearRepository academicYearRepository)
        : IRequestHandler<CreateAcademicYearCommand, AcademicYearDto>
    {
        public async Task<AcademicYearDto> Handle(CreateAcademicYearCommand request, CancellationToken cancellationToken)
    {
        var entity = new AcademicYear
        {
            Name = request.Dto.Name,
            

            StartsOn = request.Dto.StartsOn,
            

            EndsOn = request.Dto.EndsOn,
            

            IsCurrent = request.Dto.IsCurrent
        };
        var result = await academicYearRepository.AddAsync(entity); 
            await academicYearRepository.save(); 
            return new AcademicYearDto(result.Id, result.Name, result.StartsOn, result.EndsOn, result.IsCurrent); 
        }

    public async Task<bool> Handle(UpdateAcademicYearCommand request, CancellationToken cancellationToken)
    {
        var updated = await academicYearRepository.UpdateAsync(request.Id, new AcademicYear
        {
            Id = request.Id,
            

            Name = request.Dto.Name,
            

            StartsOn = request.Dto.StartsOn,
            

            EndsOn = request.Dto.EndsOn,
            

            IsCurrent = request.Dto.IsCurrent
        });
        if (updated == null) return false;
        await academicYearRepository.save(); 
            return true;
    }

    public async Task<bool> Handle(DeleteAcademicYearCommand request, CancellationToken cancellationToken)
    {
        var result = await academicYearRepository.DeleteAsync(request.Id); 
            if (result) await academicYearRepository.save(); 
            return result;
    }

    }
}

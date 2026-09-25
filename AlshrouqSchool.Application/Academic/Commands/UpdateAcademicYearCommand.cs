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
   
    public record UpdateAcademicYearCommand(int Id, UpdateAcademicYearDto Dto) : IRequest<bool>;
    public class UpdateAcademicYearCommandHandler(IAcademicYearRepository academicYearRepository)
        : IRequestHandler<UpdateAcademicYearCommand, bool>

    {

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


    }
    
}

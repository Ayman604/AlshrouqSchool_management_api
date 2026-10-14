using AlshrouqSchool.Application.Academic.DTOs;
using AlshrouqSchool.Core.Interfaces;
using AlshrouqSchool.Domain.Entities.AcademicModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Academic.Queries
{
    #region Queries 
    public record GetAllAcademicYearsQuery() : IRequest<List<AcademicYearDto>>;
    public record GetAcademicYearByIdQuery(int Id) : IRequest<AcademicYearDto?>;
    public record GetAllGradeLevelsQuery() : IRequest<List<GradeLevelDto>>;
    public record GetGradeLevelByIdQuery(int Id) : IRequest<GradeLevelDto?>;
    public record GetSectionsByGradeLevelQuery(int GradeLevelId) : IRequest<List<SectionDto>>;
    public record GetSubjectsByGradeLevelQuery(int GradeLevelId) : IRequest<List<SubjectDto>>;

    #endregion

    #region Queries  Handler 
    public class AcademicYearQueryHandler(IAcademicYearRepository academicYearRepository)
       : IRequestHandler<GetAllAcademicYearsQuery, List<AcademicYearDto>>,
         IRequestHandler<GetAcademicYearByIdQuery, AcademicYearDto?>
    {
        public async Task<List<AcademicYearDto>> Handle(GetAllAcademicYearsQuery request, CancellationToken cancellationToken)
        {
            //var query = await academicYearRepository.GetAllAsync(); 
            //return await query
            //    .Select(a => new AcademicYearDto(a.Id, a.Name, a.StartsOn, a.EndsOn, a.IsCurrent))
            //    .ToListAsync(cancellationToken);

           Task< List < AcademicYear >> academicYears = (Task<List<AcademicYear>>)await academicYearRepository.GetAllAsync();
            return (List<AcademicYearDto>)await academicYearRepository.GetAllAsync();
        }

        public async Task<AcademicYearDto?> Handle(GetAcademicYearByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await academicYearRepository.GetByIdAsync(request.Id);
            return entity == null ? null : new AcademicYearDto(entity.Id, entity.Name, entity.StartsOn, entity.EndsOn, entity.IsCurrent);
        }
    }

    #endregion

}

using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Interfaces;
using AlshrouqSchool.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Infrastructure.Repositories
{
    public class AcademicYearRepository: GenericRepository<AcademicYear>, IAcademicYearRepository
    {
    private readonly AlshrouqDbContext _db;
    public AcademicYearRepository(AlshrouqDbContext _db) : base(_db)
    {
        this._db = _db;
    }


}
    
  
}

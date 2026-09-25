using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Core.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
         Task<TEntity> AddAsync(TEntity entity);
        
         Task<bool> DeleteAsync(object Id);
        
         Task<IQueryable<TEntity>> GetAllAsync();
         Task<TEntity?> GetByIdAsync(object Id);
         Task<TEntity?> UpdateAsync(object Id, TEntity UpdatedEntity);
        Task save();
    }
}

using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Infrastructure.Data;
using AlshrouqSchool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlshrouqSchool.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(AlshrouqDbContext db) : IGenericRepository<TEntity> where TEntity : class 
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
           await db.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        public  async Task<bool> DeleteAsync(object Id)
        {
            var entity = await db.Set<TEntity>().FindAsync(Id);
            if (entity == null)  return false;
            db.Set<TEntity>().Remove(entity);
            return true;
        }
        public async Task<IQueryable<TEntity>> GetAllAsync() 
            => await Task.FromResult(db.Set<TEntity>().AsQueryable());
        public async Task<TEntity?> GetByIdAsync(object Id)
            => await db.Set<TEntity>().FindAsync(Id);
        public async Task<TEntity?> UpdateAsync(object Id, TEntity UpdatedEntity)
        {
            var OldEntity = await db.Set<TEntity>().FindAsync(Id);
            if (OldEntity == null) return null;
            db.Entry(OldEntity).CurrentValues.SetValues(UpdatedEntity);
            return UpdatedEntity;

        }


        public async Task save() 
            => await db.SaveChangesAsync();
        
    }
}

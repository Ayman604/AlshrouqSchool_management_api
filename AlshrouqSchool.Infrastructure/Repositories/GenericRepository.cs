using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlshrouqSchool.Presistence.Data.DbContexts;

namespace AlshrouqSchool.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly AlshrouqDbContext _dbContext;

        public GenericRepository(AlshrouqDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
         => await _dbContext.Set<TEntity>().AddAsync(entity);


        public void Delete(TEntity entity)
        => _dbContext.Set<TEntity>().Remove(entity);


        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(TKey Id)
              => await _dbContext.Set<TEntity>().FindAsync(Id);

        public void Update(TEntity entity)
        => _dbContext.Set<TEntity>().Update(entity);
    }
}

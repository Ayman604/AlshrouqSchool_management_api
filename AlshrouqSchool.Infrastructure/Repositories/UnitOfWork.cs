using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Interfaces;
using AlshrouqSchool.Domain.Contracts;
using AlshrouqSchool.Infrastructure.Repositories;
using AlshrouqSchool.Presistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlshrouqDbContext _dbContext;
        private readonly Dictionary<Type, object> _repository = [];
        public UnitOfWork(AlshrouqDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
           var entityType = typeof(TEntity);
            if(_repository.TryGetValue(entityType, out var repository)) 
                return (IGenericRepository<TEntity,TKey>)repository;
            
            var newRepo = new GenericRepository<TEntity,TKey>(_dbContext);
            _repository[entityType] = newRepo;
            return newRepo;
        }

        public async Task<int> SAveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentApi.Models.Interfaces;
using CarRentApi.Data;
using CarRentApi.Repository.Interfaces;

namespace CarRentApi.Repository.Base
{

    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
       where TEntity : class, IEntity
       where TContext : DbContext
    {
        private readonly CarRentApiContext _dbContext;
        public BaseRepository(CarRentApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }
        public async Task<TEntity> GetAsync(Guid guid)
        {
            return await _dbContext.Set<TEntity>().FindAsync(guid);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task DeleteAsync(Guid guid)
        {
            var entity = await GetAsync(guid).ConfigureAwait(false);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual Task<List<TEntity>> Search(object key) 
        {
            return null;
        }

    }
}

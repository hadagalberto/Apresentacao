using System;
using Microsoft.EntityFrameworkCore;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDV.Net.Domain.Entity;

namespace PDV.Net.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected DbContext Context { get; }
        protected DbSet<TEntity> EntitySet => Context.Set<TEntity>();

        public BaseRepository(PDVNetDbContext dbContext) 
        {
            Context = dbContext;
        }

        private bool IsAttached(TEntity entity) => (uint)Context.Entry(entity).State > 0U;

        public virtual async Task DeleteAsync(TEntity entity)
        {
            EntitySet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            TEntity entity = await EntitySet.FindAsync(id);
            return entity;
        }

        public virtual async Task CreateAsync(TEntity entity) 
        {
            EntitySet.Add(entity);
            await Context.SaveChangesAsync();
        }


        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (!IsAttached(entity))
                EntitySet.Update(entity);
            int num = await Context.SaveChangesAsync();
        }

        public virtual async Task<ICollection<TEntity>> ListAsync()
        {
            return await EntitySet.ToListAsync();
        }
    }
}

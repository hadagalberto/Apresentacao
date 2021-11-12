using System;
using Microsoft.EntityFrameworkCore;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDV.Net.Domain.Entity;

namespace PDV.Net.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected DbContext Context { get; }
        protected DbSet<TEntity> EntitySet => Context.Set<TEntity>();

        public Repository(PDVNetDbContext dbContext) 
        {
            Context = dbContext;
        }

        private bool IsAttached(TEntity entity) => (uint) Context.Entry(entity).State > 0U;

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (!IsAttached(entity))
                EntitySet.Remove(entity);
            else
                Context.Entry(entity).State = EntityState.Deleted;
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
            else
                Context.Entry(entity).State = EntityState.Modified;
            int num = await Context.SaveChangesAsync();
        }

        public virtual async Task<ICollection<TEntity>> ListAsync()
        {
            return await EntitySet.ToListAsync();
        }
    }
}

using PDV.Net.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDV.Net.Domain.Interface.Service
{
    public interface IService<TEntity>
        where TEntity : BaseEntity
    {
        Task DeleteAsync(TEntity entity);

        Task<ICollection<TEntity>> ListAsync();

        Task<TEntity> GetAsync(Guid id);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
    }
}

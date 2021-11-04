using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDV.Net.Domain.Entity;

namespace PDV.Net.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {

        Task DeleteAsync(TEntity entity);

        Task<ICollection<TEntity>> ListAsync();

        Task<TEntity> GetAsync(Guid id);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

    }
}

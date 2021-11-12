using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDV.Net.Domain.Service
{
    public abstract class Service<TEntity> : IService<TEntity>
        where TEntity : BaseEntity
    {

        private readonly IRepository<TEntity> _repository;

        protected Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<ICollection<TEntity>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}

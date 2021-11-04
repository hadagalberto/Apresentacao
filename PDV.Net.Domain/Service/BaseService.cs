using System;
using AutoMapper;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Domain.Interface.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Entity;

namespace PDV.Net.Domain.Service
{
    public abstract class BaseService<TViewModel, TEntity> : IBaseService<TViewModel, TEntity>
        where TViewModel : BaseDTO
        where TEntity : BaseEntity
    {

        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(TViewModel entity)
        {
            await _repository.CreateAsync(_mapper.Map<TEntity>(entity));
        }

        public async Task DeleteAsync(TViewModel entity)
        {
            await _repository.DeleteAsync(_mapper.Map<TEntity>(entity));
        }

        public async Task<TViewModel> GetAsync(Guid id)
        {
            return _mapper.Map<TViewModel>(await _repository.GetAsync(id));
        }

        public async Task<ICollection<TViewModel>> ListAsync()
        {
            return _mapper.Map<List<TViewModel>>(await _repository.ListAsync());
        }

        public async Task UpdateAsync(TViewModel entity)
        {
            await _repository.UpdateAsync(_mapper.Map<TEntity>(entity));
        }
    }
}

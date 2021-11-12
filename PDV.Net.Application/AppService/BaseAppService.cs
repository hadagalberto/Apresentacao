using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PDV.Net.Application.Interface;
using PDV.Net.Application.ViewModel;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Service;

namespace PDV.Net.Application.AppService
{
    public abstract class BaseAppService<TViewModel, TEntity, TService> : IAppService<TViewModel>
    where TViewModel : BaseViewModel
    where TEntity : BaseEntity
    where TService : IService<TEntity>
    {

        private readonly TService _service;
        private readonly IMapper _mapper;

        protected BaseAppService(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }

        public virtual async Task DeleteAsync(TViewModel viewModel)
        {
            await _service.DeleteAsync(_mapper.Map<TEntity>(viewModel));
        }

        public virtual async Task<IEnumerable<TViewModel>> ListAsync()
        {
            return _mapper.Map<IEnumerable<TViewModel>>(await _service.ListAsync());
        }

        public virtual async Task<TViewModel> GetAsync(Guid id)
        {
            return _mapper.Map<TViewModel>(await _service.GetAsync(id));
        }

        public virtual async Task CreateAsync(TViewModel viewModel)
        {
            await _service.CreateAsync(_mapper.Map<TEntity>(viewModel));
        }

        public virtual async Task UpdateAsync(TViewModel viewModel)
        {
            await _service.UpdateAsync(_mapper.Map<TEntity>(viewModel));
        }
    }
}
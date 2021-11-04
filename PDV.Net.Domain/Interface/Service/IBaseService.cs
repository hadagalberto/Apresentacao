using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Entity;

namespace PDV.Net.Domain.Interface.Service
{
    public interface IBaseService<TViewModel, TEntity>
        where TViewModel : BaseDTO
        where TEntity : BaseEntity
    {
        Task DeleteAsync(TViewModel entity);

        Task<ICollection<TViewModel>> ListAsync();

        Task<TViewModel> GetAsync(Guid id);

        Task CreateAsync(TViewModel entity);

        Task UpdateAsync(TViewModel entity);
    }
}

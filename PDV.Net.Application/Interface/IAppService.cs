using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDV.Net.Application.ViewModel;

namespace PDV.Net.Application.Interface
{
    public interface IAppService<TViewModel>
    where TViewModel: BaseViewModel
    {

        Task DeleteAsync(TViewModel entity);

        Task<IEnumerable<TViewModel>> ListAsync();

        Task<TViewModel> GetAsync(Guid id);

        Task CreateAsync(TViewModel entity);

        Task UpdateAsync(TViewModel entity);

    }
}

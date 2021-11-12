using AutoMapper;
using PDV.Net.Application.Interface;
using PDV.Net.Application.ViewModel;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Service;

namespace PDV.Net.Application.AppService
{
    public class ProdutoAppService : BaseAppService<ProdutoViewModel, Produto, IProdutoService>, IProdutoAppService
    {
        public ProdutoAppService(IProdutoService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
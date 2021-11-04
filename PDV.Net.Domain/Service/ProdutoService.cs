using AutoMapper;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Domain.Interface.Service;

namespace PDV.Net.Domain.Service
{
    public class ProdutoService : BaseService<ProdutoDTO, Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

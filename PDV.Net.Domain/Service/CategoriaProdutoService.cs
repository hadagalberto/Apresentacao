using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Domain.Interface.Service;
using System.Collections.Generic;

namespace PDV.Net.Domain.Service
{
    public class CategoriaProdutoService : Service<CategoriaProduto>, ICategoriaProdutoService
    {

        private readonly ICategoriaProdutoRepository _repository;

        public CategoriaProdutoService(ICategoriaProdutoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<CategoriaProduto> ListActive()
        {
            return _repository.ListActive();
        }
    }
}
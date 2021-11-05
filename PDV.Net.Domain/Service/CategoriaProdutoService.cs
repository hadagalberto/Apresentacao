using System.Collections.Generic;
using AutoMapper;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Domain.Interface.Service;

namespace PDV.Net.Domain.Service
{
    public class CategoriaProdutoService : BaseService<CategoriaProdutoDTO, CategoriaProduto>, ICategoriaProdutoService
    {

        private readonly ICategoriaProdutoRepository _repository;

        public CategoriaProdutoService(ICategoriaProdutoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public IEnumerable<CategoriaProdutoDTO> ListActive()
        {
            return _mapper.Map<IEnumerable<CategoriaProdutoDTO>>(_repository.ListActive());
        }
    }
}
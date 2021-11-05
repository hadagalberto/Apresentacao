using System.Collections;
using System.Collections.Generic;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Entity;

namespace PDV.Net.Domain.Interface.Service
{
    public interface ICategoriaProdutoService : IBaseService<CategoriaProdutoDTO, CategoriaProduto>
    {
        IEnumerable<CategoriaProdutoDTO> ListActive();
    }
}
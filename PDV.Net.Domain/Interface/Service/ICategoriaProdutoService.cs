using PDV.Net.Domain.Entity;
using System.Collections.Generic;

namespace PDV.Net.Domain.Interface.Service
{
    public interface ICategoriaProdutoService : IService<CategoriaProduto>
    {
        ICollection<CategoriaProduto> ListActive();
    }
}
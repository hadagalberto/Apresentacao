using System.Collections;
using System.Collections.Generic;
using PDV.Net.Domain.Entity;

namespace PDV.Net.Domain.Interface.Repository
{
    public interface ICategoriaProdutoRepository : IRepository<CategoriaProduto>
    {
        ICollection<CategoriaProduto> ListActive();
    }
}
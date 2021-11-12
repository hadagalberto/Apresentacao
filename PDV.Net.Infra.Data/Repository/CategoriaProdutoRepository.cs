using System.Collections.Generic;
using System.Linq;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Infra.Data.Context;

namespace PDV.Net.Infra.Data.Repository
{
    public class CategoriaProdutoRepository : Repository<CategoriaProduto>, ICategoriaProdutoRepository
    {
        public CategoriaProdutoRepository(PDVNetDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<CategoriaProduto> ListActive()
        {
            return EntitySet.Where(x => x.Ativo).ToList();
        }
    }
}
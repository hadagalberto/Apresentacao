using System.Collections.Generic;
using System.Linq;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Infra.Data.Context;

namespace PDV.Net.Infra.Data.Repository
{
    public class CategoriaProdutoRepository : BaseRepository<CategoriaProduto>, ICategoriaProdutoRepository
    {
        public CategoriaProdutoRepository(PDVNetDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<CategoriaProduto> ListActive()
        {
            return EntitySet.Where(x => x.Ativo).ToList();
        }
    }
}
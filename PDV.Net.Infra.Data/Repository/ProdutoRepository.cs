using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Infra.Data.Context;

namespace PDV.Net.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(PDVNetDbContext dbContext) : base(dbContext)
        {
        }
    }
}

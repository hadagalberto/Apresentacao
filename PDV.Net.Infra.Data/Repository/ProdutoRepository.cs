using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Infra.Data.Context;

namespace PDV.Net.Infra.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(PDVNetDbContext dbContext) : base(dbContext)
        {
        }
    }
}

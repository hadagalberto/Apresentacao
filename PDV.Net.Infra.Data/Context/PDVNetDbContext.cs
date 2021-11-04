using Microsoft.EntityFrameworkCore;
using PDV.Net.Domain.Entity;

namespace PDV.Net.Infra.Data.Context
{
    public class PDVNetDbContext : DbContext
    {

        public PDVNetDbContext(DbContextOptions<PDVNetDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PDVNetDbContext).Assembly);
        }
    }
}

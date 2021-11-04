using Microsoft.EntityFrameworkCore;

namespace PDV.Net.Infra.Data.Context
{
    public class PDVNetDbContext : DbContext
    {

        public PDVNetDbContext(DbContextOptions<PDVNetDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PDVNetDbContext).Assembly);
        }
    }
}

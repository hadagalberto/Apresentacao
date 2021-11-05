using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDV.Net.Domain.Entity;

namespace PDV.Net.Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.Property(x => x.HoraCriacao)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.HoraAtualizacao)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(x => x.CategoriaProduto)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.IdCategoriaProduto);
        }
    }
}

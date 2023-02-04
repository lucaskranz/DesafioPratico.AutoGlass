using DesafioPratico.AutoGlass.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPratico.AutoGlass.Infra.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Situacao)
                .IsRequired()
                .HasConversion<sbyte>();

            builder.Property(x => x.DataFabricacao)
                .HasColumnType("datetime2");

            builder.Property(x => x.DataValidade)
                .HasColumnType("datetime2");

            builder.Property(x => x.IdFornecedor)
                .HasColumnType("int");

            builder.Property(x => x.DescricaoFornecedor)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.CNPJ)
                .HasColumnType("varchar(14)");

            builder.ToTable("Produto");
        }
    }
}
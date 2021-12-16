using controlegastosapi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controlegastosapi.Mappings
{
    public class TipoPagamentoMapping : IEntityTypeConfiguration<TipoPagamento>
    {
        void IEntityTypeConfiguration<TipoPagamento>.Configure(EntityTypeBuilder<TipoPagamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("TiposPagamentos");
        }
    }
}

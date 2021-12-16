using controlegastosapi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controlegastosapi.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        void IEntityTypeConfiguration<Item>.Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Produto)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.Local)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.Loja)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.QuantidadeParcelas)
                .IsRequired()
                .HasColumnType("numeric");

            builder.Property(p => p.NumeroParcela)
                .IsRequired()
                .HasColumnType("numeric");

            builder.Property(p => p.Observacao)
                .HasColumnType("varchar(2000)");

            //// 1:1 => Item : TipoPagamento
            //builder.HasOne(it => it.TipoPagamento)
            //    .WithOne(tp => tp.Item);

            ////1 : 1 => Item : Fatura
            //builder.HasOne(it => it.Fatura)
            //    .WithOne(ft => ft.Item);

            builder.ToTable("Items");
        }
    }
}

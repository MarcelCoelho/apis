using controlegastosapi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controlegastosapi.Mappings
{
    public class FaturaMapping : IEntityTypeConfiguration<Fatura>
    {
        void IEntityTypeConfiguration<Fatura>.Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.mes)
                            .IsRequired()
                            .HasColumnType("varchar(2)");

            builder.Property(p => p.ano)
                            .IsRequired()
                            .HasColumnType("varchar(4)");

            builder.Property(p => p.DataInicio)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(p => p.DataFinal)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.ToTable("Faturas");
        }
    }
}

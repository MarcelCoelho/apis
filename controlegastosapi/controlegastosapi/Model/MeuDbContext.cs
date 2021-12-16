using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace controlegastosapi.Model
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<TipoPagamento> TiposPagamentos { get; set; }
        public DbSet<Fatura> Faturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // definir tipo caso esqueça de faze-lo no mapping
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetProperties()
            //    .Where(p => p.ClrType == typeof(string))))
            //    property.Relational().ColumnType = "varchar(100)";
       

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            // remover delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}

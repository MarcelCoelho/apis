using Microsoft.EntityFrameworkCore;

namespace controlegastosapi.Model
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}

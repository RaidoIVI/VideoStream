using Microsoft.EntityFrameworkCore;

namespace VideoStream.Data
{
    public class StorageDbContext : DbContext
    {
        public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Operation> Operations { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using VideoStream.Model;

namespace VideoStream.Data
{
    public class StorageDbContext : DbContext
    {
        public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
        {
        }

        public DbSet<VideoDescription> VideoDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoDescription>().ToTable("Description");
        }
    }
}

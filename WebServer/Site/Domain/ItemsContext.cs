using Microsoft.EntityFrameworkCore;

namespace Site.Domain
{
    public class ItemsContext : DbContext
    {
        public ItemsContext(DbContextOptions<ItemsContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Item> Items { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
        }
    }
}
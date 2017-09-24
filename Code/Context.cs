using Microsoft.EntityFrameworkCore;

namespace Keeper.Code
{
    public class Keeper : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Entry> Entries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("Data Source=./keeper.db");
            optionsBuilder.UseInMemoryDatabase("app");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Entry>()
                .HasMany<Models.Entry>(e => e.Entries)
                .WithOne(en => en.Parent);

            modelBuilder.Entity<Models.User>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
using Gameshop2.Models;
using Microsoft.EntityFrameworkCore;

namespace Gameshop2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users") // Specify the table name
                .HasKey(u => u.Id); // Specify the primary key

            modelBuilder.Entity<Game>()
                .ToTable("Games")
                .HasKey(g => g.Id);

            modelBuilder.Entity<Cart>()
                .ToTable("Carts")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Game)
                .WithMany(g => g.Carts)
                .HasForeignKey(c => c.GameId);
        }

    }
}

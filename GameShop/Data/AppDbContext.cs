using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Game> Games { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserGame> UserGames { get; set; }

    }
}

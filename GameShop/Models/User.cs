using System.ComponentModel.DataAnnotations;

namespace GameShop.Models
{
	public class User
	{
		[Key]
		public string? Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Required]
		[StringLength(50)]
		public string Email { get; set; }
		[Required]
		[StringLength(255)]
		public string Password { get; set; }

        public ICollection<UserGame>? UserGames { get; set; }

    }
}
